using PokedexGo.Interfaces;
using PokedexGo.Services;

namespace PokedexGo.Facades;

internal class RegisterNewUserFacade : IRegisterNewUserFacade
{
    // Jag har valt att använda en facade av att registrera nya användare. Då kan jag dela upp det i flera steg, först
    // kontrollera så att man inte valt ett användarnamn som redan finns i databasen. Sedan kontrolleras så att lösenordet
    // inte är tomt eller innehåller whitespaces. RegisterNewUserFasade var min första tanke på val av design patterns för
    // att det kändes logiskt att kunna addera komplexitet när man lägger till nya användare såsom att till exempel
    // användarnamn ska vara unikt samt att lösenordet ska vara korrekt (ej tomt och inga mellanslag).
    // Här kan man addera ytterligare valideringar såsom att mailadressen ska innehålla enligt ett regex-mönster exempelvis,
    // eller att perssonnummer ska innehålla x antal tecken osv. Och från loginpageviewmodel är det fortfarande endast ett
    // enda metodanrop. Super smidigt.

    private readonly ValidateUsernameService _validateUsername;
    private readonly IValidatePassword _validatePassword;

    public RegisterNewUserFacade()
    {
        _validateUsername = new ValidateUsernameService();
        _validatePassword = new ValidatePasswordService();
    }

    public async Task<string> CanRegister(string username, string password)
    {
        var isValidUsername = await _validateUsername.ValidateUsernameAsync(username);
        if (!isValidUsername)
            return $"The username \"{username}\" already exists";

        var isValidPassword = _validatePassword.ValidatePassword(password);
        if (!isValidPassword)
            return $"The password is incorrect";

        return string.Empty;
    }
}
