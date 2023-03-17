using PokedexGo.Models;

namespace PokedexGo.Helpers;

public static class PokemonHelper
{
    public static List<Pokemon> CapitalizeFirstLetters(this List<Pokemon> pokemonList)
    {
        foreach (var pokemon in pokemonList)
        {
            pokemon.Name = pokemon.Name[..1].ToUpper() + pokemon.Name[1..].ToLower();
        }
        return pokemonList;
    }

    public static Pokemon CapitalizeFirstLetter(this Pokemon pokemon)
    {
        pokemon.Name = pokemon.Name[..1].ToUpper() + pokemon.Name[1..].ToLower();
        return pokemon;
    }
}
