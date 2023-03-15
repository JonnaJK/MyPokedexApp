namespace PokedexGo.Interfaces;

internal interface IAuthorization
{
    bool IsAuthenticated(string username, string password);
}
