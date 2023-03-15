namespace PokedexGo.Interfaces;

internal interface ILoginFacade
{
    bool CanLogin(string username, string password);
}
