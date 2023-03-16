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
    #endregion

    public ShowMyPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _pokeService = ServiceHelper.GetService<PokeService>();

        var task = Task.Run(() => _pokeService.GetUsersPokemon(_user.Pokemon));
        task.Wait();

        Pokemon = task.Result.ToList().CapitalizeFirstLetters();
    }

    #region Commands
    public ICommand GoToPokemonDetailsPageCommand => new Command<Pokemon>(async (pokemon) =>
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Pokemon", pokemon }
        };
        await Shell.Current.GoToAsync(nameof(PokemonDetailsPage), navigationParameter);
    });
    #endregion
}
