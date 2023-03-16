using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Views;
using System.Windows.Input;
using PokedexGo.Helpers;
using PokedexGo.Interfaces;

namespace PokedexGo.ViewModels;

public partial class LoginPageViewModel : ViewModelBase
{
    #region Attributes
    private readonly User _user;
    private readonly UserService _userService;
    private readonly AlertService _alertService;
    private readonly PokeService _pokeService;
    private readonly ILoginFacade _loginFacade;
    private readonly IRegisterNewUserFacade _registerNewUserFacade;
    private string _username;
    private string _password;
    #endregion

    #region Properties
    public ICommand LoginCommand { get; private set; }
    public ICommand RegisterNewUserCommand { get; private set; }
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
        try
        {
            var loginFailMessage = await _loginFacade.CanLogin(Username, Password);
            if (!string.IsNullOrWhiteSpace(loginFailMessage))
            {
                await _alertService.ShowAlertAsync("Incorrect", loginFailMessage, "OK");
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
        catch (Exception e)
        {
            await _alertService.ShowAlertAsync("Exception", e.Message, "OK");
        }
    }

    public async Task RegisterNewUser()
    {
        try
        {
            var registerFailMessage = await _registerNewUserFacade.CanRegister(Username, Password);
            if (!string.IsNullOrWhiteSpace(registerFailMessage))
            {
                await _alertService.ShowAlertAsync("Incorrect", registerFailMessage, "OK");
                return;
            }

            _user.Id = new Guid();
            _user.Username = Username;
            _user.Password = Password;
            _user.Pokemon.Add(PokeService.GetRandomPokemon());

            await _userService.CreateUserAsync(_user);
            await Shell.Current.GoToAsync(nameof(MyPokemonPage));
        }
        catch (Exception e)
        {
            await _alertService.ShowAlertAsync("Exception", e.Message, "OK");
        }
    }
    #endregion
}
