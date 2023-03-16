using PokedexGo.Helpers;
using PokedexGo.Interfaces;

namespace PokedexGo.Services;

internal class AuthenticatePasswordService : IAuthenticatePassword
{
    private readonly UserService _userService;

    public AuthenticatePasswordService()
    {
        _userService = ServiceHelper.GetService<UserService>();
    }

    public async Task<bool> IsAuthenticated(string username, string password)
    {
        var user = await _userService.GetUserAsync(username, password);
        return user is not null;
    }
}
