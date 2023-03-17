using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public class CatchEmAllPageViewModel : ViewModelBase
{
    #region Consts
    private const int MAX_POKEMON_ID_REQUEST = 906;
    private const int MAX_CAPTURE_RATE = 255;
    #endregion

    #region Attributes
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private AlertService _alertService;
    private Pokemon _pokemon;
    private SpeciesDetail _speciesDetail;
    #endregion

    #region Properties
    public Pokemon Pokemon
    {
        get => _pokemon;
        set
        {
            _pokemon = value;
            _ = Task.Run(async () => { SpeciesDetail = await _pokeService.GetFromUrl<SpeciesDetail>(_pokemon.Species.Url); });
            OnPropertyChanged(nameof(Pokemon));
        }
    }
    public SpeciesDetail SpeciesDetail
    {
        get => _speciesDetail;
        set
        {
            _speciesDetail = value;
            OnPropertyChanged(nameof(SpeciesDetail));
        }
    }
    public ICommand ThrowPokeBallCommand { get; private set; }
    public ICommand SkipPokemonCommand { get; private set; }
    #endregion

    public CatchEmAllPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();

        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        _alertService = ServiceHelper.GetService<AlertService>();

        _ = GetRandomPokemon();

        ThrowPokeBallCommand = new Command(async () => await ThrowPokeBall());
        SkipPokemonCommand = new Command(async () => await SkipPokemon());
    }

    #region Commands
    private async Task ThrowPokeBall()
    {
        try
        {
            var random = new Random();

            var title = "Status";
            var cancelButton = "OK";

            string message;
            if (random.Next(MAX_CAPTURE_RATE) <= SpeciesDetail.CaptureRate)
            {
                message = $"Gotcha! {Pokemon.Name} was caught!";

                _user.Pokemon.Add(new Pokemon { Name = Pokemon.Name.ToLower() });
                await _userService.UpdateUserAsync(_user);
            }
            else
            {
                message = $"Oh, no! The {Pokemon.Name} broke free!";
            }

            await _alertService.ShowAlertAsync(title, message, cancelButton);

            await GetRandomPokemon();
        }
        catch (Exception e)
        {
            await _alertService.ShowAlertAsync($"Exception in {nameof(ThrowPokeBall)}", e.Message, "OK");
        }
    }

    private async Task SkipPokemon() =>
        await GetRandomPokemon();

    public async Task GetRandomPokemon()
    {
        try
        {
            var random = new Random();
            Pokemon = (await _pokeService.GetRandomPokemonById(random.Next(MAX_POKEMON_ID_REQUEST)))
                .CapitalizeFirstLetter();
        }
        catch (Exception e)
        {
            _alertService.ShowAlert("Exception", e.Message, "OK");
        }
    }
    #endregion
}
