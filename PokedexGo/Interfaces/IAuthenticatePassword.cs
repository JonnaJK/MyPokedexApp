namespace PokedexGo.Interfaces;

internal interface IAuthenticatePassword
{
    Task<bool> IsAuthenticated(string username, string password);
}
