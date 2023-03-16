using PokedexGo.Helpers;
using PokedexGo.Models;
using System.Collections.Concurrent;

namespace PokedexGo.Services;

internal class PokeService
{
    private readonly HttpService _httpService;

    public PokeService()
    {
        _httpService = ServiceHelper.GetService<HttpService>();
    }

    public async Task<List<Pokemon>> GetUsersPokemon(List<Pokemon> usersPokemon)
    {
        var bag = new ConcurrentBag<Pokemon>();

        await Parallel.ForEachAsync(usersPokemon, 
            async (pokemon, token) =>
            {
                // TODO: Skrv en kommentar om varför jag gör detta, databas full pokemon. och anonym funktion
                var retrievedPokemon = await GetPokemonByName(pokemon.Name);
                retrievedPokemon.IsWanted = pokemon.IsWanted;
                retrievedPokemon.IsFavorite = pokemon.IsFavorite;
                bag.Add(retrievedPokemon);
            });

        return bag.OrderByDescending(x => x.IsFavorite).ThenBy(x => x.Id).ToList();
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
