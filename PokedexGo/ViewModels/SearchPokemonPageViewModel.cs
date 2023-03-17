using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public class SearchPokemonPageViewModel : ViewModelBase
{
    #region Attributes
    private Pokemon _pokemon;
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private AlertService _alertService;
    private string _pokemonNameEntry;
    private SpeciesDetail _speciesDetail;
    private string _imageSource;
    private string _flavorText;
    #endregion

    #region Properties
    public string ImageSource
    {
        get => _imageSource;
        set
        {
            _imageSource = value;
            OnPropertyChanged(nameof(ImageSource));
        }
    }
    public string PokemonNameEntry
    {
        get => _pokemonNameEntry;
        set
        {
            _pokemonNameEntry = value;
            OnPropertyChanged(nameof(PokemonNameEntry));
        }
    }
    public Pokemon Pokemon
    {
        get => _pokemon;
        set
        {
            _pokemon = value;
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
    public string FlavorText
    {
        get => _flavorText;
        set
        {
            _flavorText = value;
            OnPropertyChanged(nameof(FlavorText));
        }
    }
    public ICommand SearchCommand { get; private set; }
    #endregion

    public SearchPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();

        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        _alertService = ServiceHelper.GetService<AlertService>();

        SearchCommand = new Command(async () => await SearchPokemon());
    }

    #region Commands
    private async Task SearchPokemon()
    {
        try
        {
            Pokemon = (await _pokeService.GetPokemonByName(PokemonNameEntry.ToLower())).CapitalizeFirstLetter();
            SpeciesDetail = await _pokeService.GetFromUrl<SpeciesDetail>(_pokemon.Species.Url);
            FlavorText = SpeciesDetail.FlavorTextEntries.Where(x => x.Language.Name == "en").FirstOrDefault().FlavorText;
            ImageSource = "";
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode is System.Net.HttpStatusCode.NotFound)
                await _alertService.ShowAlertAsync("Search", "Pokemon was not found", "OK");
            else
                await _alertService.ShowAlertAsync(nameof(HttpRequestException), e.Message, "OK");
        }
        catch (Exception e)
        {
            _alertService.ShowAlert(nameof(Exception), e.Message, "OK");
        }
    }

    public ICommand BuyFromTeamRocketCommand => new Command(async () =>
    {
        try
        {
            if (Pokemon is null)
            {
                await _alertService.ShowAlertAsync("Empty", "There is not pokemon to buy from Team Rocket", "OK");
                return;
            }

            var random = new Random();
            ImageSource = "teamrocket.png";
            if (random.Next(101) <= 25)
            {
                await _alertService.ShowAlertAsync("Too bad..", "Team Rocket ripped you of. " +
                    "Thats what you get for trading with criminals", "SHAME");
                FlavorText = "Prepare for trouble!\r\n" +
                            "And make it double!\r\n" +
                            "To protect the world from devastation!\r\n" +
                            "To unite all peoples within our nation!\r\n" +
                            "To denounce the evils of truth and love!\r\n" +
                            "To extend our reach to the stars above!\r\n" +
                            "Jessie!\r\n" +
                            "James!\r\n" +
                            "Team Rocket blasts off at the speed of light!\r\n" +
                            "Surrender now, or prepare to fight!\r\n" +
                            "Meowth!\r\n" +
                            "That's right!";
                return;
            }
            _user.Pokemon.Add(new Pokemon { Name = Pokemon.Name.ToLower(), IsFavorite = Pokemon.IsFavorite, IsWanted = Pokemon.IsWanted });
            await _userService.UpdateUserAsync(_user);
            await _alertService.ShowAlertAsync("Success", $"You bought the pokemon from the black market", "OK");
        }
        catch (Exception e)
        {
            await _alertService.ShowAlertAsync("Exception", e.Message, "OK");
        }
    });

    public ICommand AddToWantedListCommand => new Command(async () =>
    {
        try
        {
            _user.WantedPokemon.Add(new Pokemon { Name = Pokemon.Name });
            await _userService.UpdateUserAsync(_user);
            await _alertService.ShowAlertAsync("Confirmation", "Pokemon was successfully added to your wanted list", "OK");
        }
        catch (Exception e)
        {
            _alertService.ShowAlert("Exception", e.Message, "OK");
        }
    });
    #endregion
}
