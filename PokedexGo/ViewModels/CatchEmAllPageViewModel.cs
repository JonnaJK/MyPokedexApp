using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public class CatchEmAllPageViewModel : ViewModelBase
{
    #region Consts
    private const int TASK_DELAY_TIME = 5_000;
    private const int MAX_POKEMON_ID_REQUEST = 906;
    // The base capture rate; up to 255. The higher the number, the easier the catch.
    private const int MAX_CAPTURE_RATE = 260;
    #endregion

    #region Attributes
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private AlertService _alertService;
    private bool _isGonnaCatchEmAll = true;
    private bool _isShowing = true;
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
    public ICommand StartCatchingCommand { get; private set; }
    public ICommand StopCatchingCommand { get; private set; }
    public ICommand CatchCommand { get; private set; }
    #endregion

    public CatchEmAllPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        _alertService = ServiceHelper.GetService<AlertService>();

        StartCatchingCommand = new Command(async () => await CatchRandomPokemon());
        StopCatchingCommand = new Command(() => StopCatching());
        CatchCommand = new Command(async () => await Catch());
    }

    #region Commands
    public async Task CatchRandomPokemon()
    {
        var random = new Random();
        while (_isGonnaCatchEmAll)
        {
            await Task.Delay(TASK_DELAY_TIME);
            if (_isShowing)
            {
                Pokemon = await _pokeService.GetRandomPokemonById(random.Next(MAX_POKEMON_ID_REQUEST));
                Pokemon = ShowMyPokemonPageViewModel.CapitalizeFirstLetter(Pokemon);
            }
        }
    }

    public async Task Catch()
    {
        _isShowing = false;
        Pokemon = null;

        var random = new Random();

        var title = "Status";
        var cancelButton = "OK";
        string message;
        if (random.Next(MAX_CAPTURE_RATE) <= SpeciesDetail.CaptureRate)
        {
            // fångad
            message = $"Gotcha! {Pokemon.Name} was caught!";
        }
        else
        {
            // inte fångad
            message = $"Oh, no! The {Pokemon.Name} broke free!";
        }

        await _alertService.ShowAlertAsync(title, message, cancelButton);

        _user.Pokemon.Add(new Pokemon { Name = Pokemon.Name.ToLower() });
        await _userService.UpdateUserAsync(_user);

        _isShowing = true;
    }

    public void StopCatching() =>
        _isGonnaCatchEmAll = false;
    #endregion
}
