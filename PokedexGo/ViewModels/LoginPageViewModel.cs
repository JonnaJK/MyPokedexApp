using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Views;
using System.Windows.Input;
using PokedexGo.Helpers;
using PokedexGo.Interfaces;
using PokedexGo.Facades;

namespace PokedexGo.ViewModels;

public partial class LoginPageViewModel : ViewModelBase
{
    #region Attributes
    private User _user;
    private UserService _userService;
    private AlertService _alertService;
    private ILoginFacade _loginFacade;
    private IRegisterNewUserFacade _registerNewUserFacade;
    private string _username;
    private string _password;
    #endregion

    #region Properties
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public List<Pokemon> Pokemons { get; set; }
    public Action<User> SignedIn { get; set; }
    public ICommand LoginCommand { get; private set; }
    public ICommand RegisterNewUserCommand { get; private set; }
    #endregion

    public LoginPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _userService = ServiceHelper.GetService<UserService>();
        _alertService = ServiceHelper.GetService<AlertService>();
        _loginFacade = ServiceHelper.GetService<ILoginFacade>();
        _registerNewUserFacade = ServiceHelper.GetService<IRegisterNewUserFacade>();

        LoginCommand = new Command(async () => await Login());
        RegisterNewUserCommand = new Command(async () => await RegisterNewUser());
    }

    #region Commands
    public async Task Login()
    {
        var message = await _loginFacade.CanLogin(Username, Password);
        if (!string.IsNullOrWhiteSpace(message))
        {
            await _alertService.ShowAlertAsync("Incorrect", message, "OK");
            return;
        }

        var user = await _userService.GetUserAsync(Username, Password);
        if (user is null)
            return;

        _user.Id = user.Id;
        _user.Username = user.Username;
        _user.Password = user.Password;
        _user.Pokemon = user.Pokemon;
        _user.FavoritePokemon = user.FavoritePokemon;
        _user.WantedPokemon = user.WantedPokemon;

        await Shell.Current.GoToAsync(nameof(MyPokemonPage));
    }

    public async Task RegisterNewUser()
    {
        var message = await _registerNewUserFacade.CanRegister(Username, Password);
        if (!string.IsNullOrWhiteSpace(message))
        {
            await _alertService.ShowAlertAsync("ValidationMessage", message, "OK");
            return;
        }

        // TODO: Randomisa sin starter pokemon!! 1% för pikachu, 33 för charmander, 33 för bulbasaur, 33 för squirtle
        _user.Id = new Guid();
        _user.Username = Username;
        _user.Password = Password;
        _user.Pokemon = new List<Pokemon> { new Pokemon { Name = "pikachu" } };

        await _userService.CreateUserAsync(_user);
        await Shell.Current.GoToAsync(nameof(MyPokemonPage));
    }
    #endregion
}
