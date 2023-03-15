namespace PokedexGo.Interfaces;

internal interface IAuthentication
{
    bool IsAuthenticated(string username, string password);
}
