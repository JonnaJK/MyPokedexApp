namespace PokedexGo.Interfaces;

internal interface IRegisterNewUserFacade
{
    Task<string> CanRegister(string username, string password);
}
