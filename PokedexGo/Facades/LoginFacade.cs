using PokedexGo.Interfaces;
using PokedexGo.Services;

namespace PokedexGo.Facades;

internal class LoginFacade : ILoginFacade
{
    // Jag har valt att använda en facade av att logga in för att kunna hämta användare (om den finns),
    // kontrollera lösenordet men i "vanliga" koden ser man endast en funktionsanrop.
    // En enkel "yta/fasad" i Loginsidan. På detta sätt har man även möjlighet att
    // lägga till ytterligare valideringar som mail exempelvis

    private readonly IAuthenticateUsername _authenticationUsername;
    private readonly IAuthenticatePassword _authenticationPassword;

    public LoginFacade()
    {
        _authenticationUsername = new AuthenticateUsernameService();
        _authenticationPassword = new AuthenticatePasswordService();
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
