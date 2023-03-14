using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Views;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public partial class ShowMyPokemonPageViewModel : ViewModelBase
{
    private User _user;
    private PokeService _pokeService;
    private List<Pokemon> _pokemons;
    public List<Pokemon> Pokemons
    {
        get => _pokemons;
        set
        {
            _pokemons = value;
            OnPropertyChanged(nameof(Pokemons));
        }
    }
    public ICommand GoToPokemonDetailsPageCommand { get; private set; }

    // TODO: Make the list automaticly updated whenever you enter the page, switch to transient?
    public ShowMyPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _pokeService = ServiceHelper.GetService<PokeService>();

        var task = Task.Run(() => _pokeService.GetUsersPokemonASD(_user.Pokemons));
        task.Wait();

        // TODO: Ändra Pokemons till Pokemon överallt
        Pokemons = task.Result.ToList();
        Pokemons = CapitalizeFirstLetters(Pokemons);

        GoToPokemonDetailsPageCommand = new Command(async (pokemon) => await GoToPokemonDetailsPage(pokemon));
    }

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
