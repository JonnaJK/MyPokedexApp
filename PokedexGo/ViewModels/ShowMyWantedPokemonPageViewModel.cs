using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public class ShowMyWantedPokemonPageViewModel : ViewModelBase
{
    #region Attributes
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private readonly AlertService _alertService;
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

    public ShowMyWantedPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();

        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        _alertService = ServiceHelper.GetService<AlertService>();
        try
        {
            var task = Task.Run(() => _pokeService.GetUsersPokemon(_user.WantedPokemon));
            task.Wait();
            Pokemon = task.Result.ToList().CapitalizeFirstLetters();
        }
        catch (Exception e)
        {
            _alertService.ShowAlert("Exception", e.Message, "OK");
        }

    }

    #region Commands
    public ICommand RemoveIsWantedCommand => new Command<Pokemon>(async (pokemon) =>
    {
        try
        {
            var answer = await _alertService.ShowConfirmationAsync("Warning!", $"Do you wish to remove Pokemon {pokemon.Name} as wanted?", "Yes", "No");
            if (answer is false)
                return;

            Pokemon.Remove(pokemon);

            pokemon.IsWanted = !pokemon.IsWanted;
            _user.Pokemon.FindAll(x => x.Name == pokemon.Name.ToLower()).ForEach(x => x.IsWanted = pokemon.IsWanted);
            _user.WantedPokemon.Remove(_user.WantedPokemon.Find(x => x.Name == pokemon.Name.ToLower()));

            await _userService.UpdateUserAsync(_user);
            OnPropertyChanged(nameof(Pokemon));
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            _alertService.ShowAlert("Exception", e.Message, "OK");
        }
    });
    #endregion
}
