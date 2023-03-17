using PokedexGo.Helpers;
using PokedexGo.Interfaces;
using PokedexGo.Services;

namespace PokedexGo.Facades;

internal class LoginFacade : ILoginFacade
{
    // Jag har valt att använda en facade av att logga in för att kunna göra det mer komplext i två olika delar med att hämta användare
    // samt att kontrollera lösenordet och samtidigt ha en enkel "yta/fasad" i Loginsidan med ett anrop till fasad.
    // På detta sätt har man även möjlighet att lägga till ytterligare valideringar som mail exempelvis

    private readonly IAuthenticateUsername _authenticationUsername;
    private readonly IAuthenticatePassword _authenticationPassword;
    private readonly AlertService _alertService;

    public LoginFacade()
    {
        _authenticationUsername = new AuthenticateUsernameService();
        _authenticationPassword = new AuthenticatePasswordService();

        _alertService = ServiceHelper.GetService<AlertService>();
    }

    public async Task<string> CanLogin(string username, string password)
    {
        var isAuthenticated =
        await _authenticationUsername.IsAuthenticated(username) &&
        await _authenticationPassword.IsAuthenticated(username, password);

        return isAuthenticated ?
            string.Empty :
            $"The username or password is incorrect";
    }
}
