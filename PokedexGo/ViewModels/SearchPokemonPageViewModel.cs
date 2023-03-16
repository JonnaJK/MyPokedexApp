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
    #endregion

    #region Properties
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
    public string FlavorText { get; private set; }
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
            Pokemon = await _pokeService.GetPokemonByName(PokemonNameEntry.ToLower());
            SpeciesDetail = await _pokeService.GetFromUrl<SpeciesDetail>(_pokemon.Species.Url);
            FlavorText = SpeciesDetail.FlavorTextEntries.Where(x => x.Language.Name == "en").FirstOrDefault().FlavorText;
            OnPropertyChanged(nameof(FlavorText));

            if (Pokemon != null)
            {
                // TODO: Här är jag
                // Buy from team rocket, lägg till bild på dom om det finns och om köpet går igenom
            }
        }
        catch (Exception e)
        {
            _alertService.ShowAlert("Exception", e.Message, "OK");
        }
    }

    public ICommand AddToWantedListCommand => new Command(async () =>
    {
        try
        {
            _user.WantedPokemon.Add(new Pokemon { Name = Pokemon.Name });
            await _userService.UpdateUserAsync(_user);
        }
        catch (Exception e)
        {
            _alertService.ShowAlert("Exception", e.Message, "OK");
        }
    });
    #endregion
}
