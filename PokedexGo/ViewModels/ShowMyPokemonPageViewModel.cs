using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Views;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public partial class ShowMyPokemonPageViewModel : ViewModelBase
{
    #region Attributes
    private User _user;
    private PokeService _pokeService;
    private List<Pokemon> _pokemon;
    #endregion

    #region Properties
    public List<Pokemon> Pokemon
    {
        get => _pokemon;
        set
        {
            _pokemon = value;
            OnPropertyChanged(nameof(Pokemon));
        }
    }
    public ICommand GoToPokemonDetailsPageCommand { get; private set; }
    #endregion

    public ShowMyPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _pokeService = ServiceHelper.GetService<PokeService>();

        var task = Task.Run(() => _pokeService.GetUsersPokemon(_user.Pokemon));
        task.Wait();

        // TODO: Ändra Pokemons till Pokemon överallt
        Pokemon = task.Result.ToList();
        Pokemon = CapitalizeFirstLetters(Pokemon);

        GoToPokemonDetailsPageCommand = new Command(async (pokemon) => await GoToPokemonDetailsPage(pokemon));
    }

    // TODO: NEW kanske bör vara i PokemonHelpers?
    public static List<Pokemon> CapitalizeFirstLetters(List<Pokemon> pokemonList)
    {
        foreach (var pokemon in pokemonList)
        {
            pokemon.Name = pokemon.Name[..1].ToUpper() + pokemon.Name[1..].ToLower();
        }
        return pokemonList;
    }

    public ICommand SelectedItemCommand => new Command<Pokemon>(async (pokemon) =>
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Pokemon", pokemon }
        };
        await Shell.Current.GoToAsync(nameof(PokemonDetailsPage), navigationParameter);
    });

    public async Task GoToPokemonDetailsPage(object pokemon) =>
        await Shell.Current.GoToAsync(nameof(PokemonDetailsPage), new Dictionary<string, object> { { "Pokemon", pokemon as Pokemon } });
}
