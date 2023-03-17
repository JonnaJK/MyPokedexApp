using PokedexGo.Helpers;
using PokedexGo.Interfaces;
using PokedexGo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.Facades;

internal class RegisterNewUserFacade : IRegisterNewUserFacade
{
    // Jag har valt att använda en facade av att registrera nya användare. Då kan jag dela upp det i flera steg, först
    // kontrollera så att man inte valt ett användarnamn som redan är upptaget. Sedan för att kontrollera så att lösenordet
    // inte är tomt eller innehåller mellanslag. RegisterNewUserFasade var min första tanke på val av design patterns för
    // att det kändes logiskt att kunna addera komplexitet med att användarnamn ska vara unikt samt att lösenordet ska
    // vara korrekt (ej tomt och inga mellanslag) och det enda som "syns" i loginpageviewmodel är en metodanrop.
    // Här kan man addera ytterligare valideringar såsom att mailadressen ska innehålla enligt ett regex-mönster,
    // perssonnummer ska innehålla x antal tecken osv. Och från loginpageviewmodel är det fortfarande endast ett
    // enda metodanrop. Super smidigt.

    private readonly ValidateUsernameService _validateUsername;
    private readonly IValidatePassword _validatePassword;
    private readonly AlertService _alertService;

    public RegisterNewUserFacade()
    {
        _validateUsername = new ValidateUsernameService();
        _validatePassword = new ValidatePasswordService();

        _alertService = ServiceHelper.GetService<AlertService>();
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
