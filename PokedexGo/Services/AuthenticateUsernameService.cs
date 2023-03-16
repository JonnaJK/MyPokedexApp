using PokedexGo.Helpers;
using PokedexGo.Interfaces;

namespace PokedexGo.Services;

internal class AuthenticateUsernameService : IAuthenticateUsername
{
    private UserService _userService;
    public AuthenticateUsernameService()
    {
        _userService = ServiceHelper.GetService<UserService>();
    }

    public async Task<bool> IsAuthenticated(string username)
    {
        var user = await _userService.GetUserAsync(username);
        return user is not null;
    }
}
