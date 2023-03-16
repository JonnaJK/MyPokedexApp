using PokedexGo.Interfaces;

namespace PokedexGo.Services;

internal class ValidatePasswordService : IValidatePassword
{
    public bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;
        foreach (var character in password)
        {
            if (char.IsWhiteSpace(character))
                return false;
        }
        return true;
    }
}
