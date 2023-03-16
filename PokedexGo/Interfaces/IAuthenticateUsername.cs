namespace PokedexGo.Interfaces;

internal interface IAuthenticateUsername
{
    Task<bool> IsAuthenticated(string username);
}
