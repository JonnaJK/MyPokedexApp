using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Views;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public partial class MyPokemonPageViewModel : ViewModelBase
{
    #region Attributes
    private string _welcomeText = "Welcome!";
    private readonly User _user;
    #endregion


    #region Properties
    public string WelcomeText
    {
        get => _welcomeText;
        set
        {
            _welcomeText = $"Welcome {_user.Username}!";
            OnPropertyChanged(nameof(WelcomeText));
        }
    }
    public ICommand GoToShowMyPokemonsPageCommand { get; private set; }
    public ICommand GoToCatchEmAllPageCommand { get; private set; }
    public ICommand GoToSearchPokemonPageCommand { get; private set; }

    #endregion

    public MyPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        GoToShowMyPokemonsPageCommand = new Command(async () => await GoToShowMyPokemonsPage());
        GoToCatchEmAllPageCommand = new Command(async () => await GoToCatchEmAllPage());
        GoToSearchPokemonPageCommand = new Command(async () => await GoToSearchPokemonPage());
    }

    #region Commands
    public async Task GoToShowMyPokemonsPage() =>
        await Shell.Current.GoToAsync(nameof(ShowMyPokemonPage));

    public async Task GoToCatchEmAllPage() =>
        await Shell.Current.GoToAsync(nameof(CatchEmAllPage));

    public async Task GoToSearchPokemonPage() =>
        await Shell.Current.GoToAsync(nameof(SearchPokemonPage));
    #endregion
}
