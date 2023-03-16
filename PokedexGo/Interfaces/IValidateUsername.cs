namespace PokedexGo.Interfaces;

internal interface IValidateUsername
{
    Task<bool> ValidateUsernameAsync(string username);
}
