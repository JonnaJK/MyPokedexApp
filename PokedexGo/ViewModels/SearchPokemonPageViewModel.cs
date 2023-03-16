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
            if (Pokemon != null)
            {
                // got to detail
                // But from team rocket, lägg till bild på dom om det finns och om köpet går igenom
            }
        }
        catch (Exception e)
        {

        }
    }
    #endregion
}
