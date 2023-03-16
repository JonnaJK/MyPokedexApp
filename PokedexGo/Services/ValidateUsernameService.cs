using PokedexGo.Helpers;
using PokedexGo.Interfaces;

namespace PokedexGo.Services;

internal class ValidateUsernameService : IValidateUsername
{
    private UserService _userService;

    public ValidateUsernameService()
    {
        _userService = ServiceHelper.GetService<UserService>();
    }

    public async Task<bool> ValidateUsernameAsync(string username)
    {
        var user = await _userService.GetUserAsync(username);
        return user == null;
    }
}
