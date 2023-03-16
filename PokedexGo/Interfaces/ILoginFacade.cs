namespace PokedexGo.Interfaces;

internal interface ILoginFacade
{
    Task<string> CanLogin(string username, string password);
}
