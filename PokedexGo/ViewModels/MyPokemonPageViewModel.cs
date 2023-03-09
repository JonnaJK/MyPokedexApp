using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Views;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

public partial class MyPokemonPageViewModel : ViewModelBase
{
    private string _welcomeText = "Welcome!";
    public string WelcomeText
    {
        get => _welcomeText;
        set
        {
            _welcomeText = $"Welcome {_user.UserName}!";
            OnPropertyChanged(nameof(WelcomeText));
        }
    }
    private User _user;
    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }
    public ICommand GoToShowMyPokemonsPageCommand { get; private set; }
    public string welcomeText;
    public MyPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        GoToShowMyPokemonsPageCommand = new Command(async () => await GoToShowMyPokemonsPage());
    }

    public async Task GoToShowMyPokemonsPage()
    {
        await Shell.Current.GoToAsync(nameof(ShowMyPokemonPage));
    }
}
