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
    private const int MAX_CAPTURE_RATE = 255;
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
            // TODO: Ändra som ovan på andra ställen som använder task.wait
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

    public async Task CatchRandomPokemon()
    {
        var random = new Random();
        while (_isGonnaCatchEmAll)
        {
            await Task.Delay(TASK_DELAY_TIME);
            if (_isShowing)
            {
                Pokemon = await _pokeService.GetRandomPokemonById(random.Next(MAX_POKEMON_ID_REQUEST));

                var pokemon = ShowMyPokemonPageViewModel.CapitalizeFirstLetters(new List<Pokemon> { Pokemon });
                Pokemon = pokemon.First();
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
        if (SpeciesDetail.CaptureRate < 25.5)
        {
            message = "10%";
            // 10% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 50)
        {
            message = "20%";
            // 20% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 76.5)
        {
            message = "30%";
            // 30% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 102)
        {
            message = "40%";
            // 40% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 127.5)
        {
            message = "50%";
            // 50% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 153)
        {
            message = "60%";
            // 60% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 178.5)
        {
            message = "70%";
            // 70% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 204)
        {
            message = "80%";
            // 80% chans att fånga
        }
        else if (SpeciesDetail.CaptureRate > 229.5)
        {
            message = "90%";
            // 90% chans att fånga
        }
        else
        {
            message = "100%";
            // 100% chans att fånga
        }

        await _alertService.ShowAlertAsync(title, message, cancelButton);

        _user.Pokemon.Add(new Pokemon { Name = Pokemon.Name.ToLower() });
        await _userService.UpdateUserAsync(_user);

        _isShowing = true;
    }

    public void StopCatching() =>
        _isGonnaCatchEmAll = false;
}
