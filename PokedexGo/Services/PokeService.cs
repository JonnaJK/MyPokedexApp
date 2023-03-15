using PokedexGo.Models;

namespace PokedexGo.Services;

internal class PokeService
{
    private readonly HttpService _httpService;

    public PokeService()
    {
        _httpService = new HttpService();
    }

    // TODO: NEW Bör kanske vara i PokemonHelper?
    public async Task<List<Pokemon>> GetUsersPokemon(List<Pokemon> usersPokemon)
    {
        var list = new List<Pokemon>();
        foreach (var pokemon in usersPokemon)
        {
            var retrievedPokemon = await GetPokemonByName(pokemon.Name);
            retrievedPokemon.IsWanted = pokemon.IsWanted;
            retrievedPokemon.IsFavorite = pokemon.IsFavorite;
            list.Add(retrievedPokemon);
        }
        return list;
    }

    public async Task<Pokemon> GetRandomPokemonById(int pokemonId) =>
        await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemonId}");

    public async Task<Pokemon> GetPokemonByName(string pokemonName) =>
        await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemonName}");

    public async Task<Pokemon> GetType(int type) =>
        await _httpService.HttpRequest<Pokemon>($"type/{type}");

    public async Task<T> GetFromUrl<T>(Uri url) =>
        await _httpService.HttpRequest<T>(url);
}
