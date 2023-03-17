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
                // Implementerar anonym funktion och delegat.
                // I databasen sparar jag users fångade pokemon endast med Name, IsFavorite and IsWanted properties.
                // När jag försökte spara med fullständig information fick jag en error
                // MongoDB.Bson.BsonSerializationException som jag inte förstod/lyckades lösa.
                var retrievedPokemon = await GetPokemonByName(pokemon.Name);
                retrievedPokemon.IsWanted = pokemon.IsWanted;
                retrievedPokemon.IsFavorite = pokemon.IsFavorite;
                bag.Add(retrievedPokemon);
            });

        return bag.OrderByDescending(x => x.IsFavorite).ThenBy(x => x.Id).ToList();
    }

    public static Pokemon GetRandomPokemon()
    {
        var random = new Random();
        return StarterPokemon(random.Next(101));
    }

    public static Pokemon StarterPokemon(int number) => number switch
    {
        int when number <= 10 => new Pokemon { Name = "pikachu" },
        int when number > 10 && number <= 40 => new Pokemon { Name = "bulbasaur" },
        int when number > 40 && number <= 70 => new Pokemon { Name = "charmander" },
        int when number > 70 && number <= 100 => new Pokemon { Name = "squirtle" },
        _ => throw new NotImplementedException()
    };

    public async Task<Pokemon> GetRandomPokemonById(int pokemonId) =>
        await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemonId}");

    public async Task<Pokemon> GetPokemonByName(string pokemonName) =>
        await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemonName}");

    public async Task<Pokemon> GetType(int type) =>
        await _httpService.HttpRequest<Pokemon>($"type/{type}");

    public async Task<TypeDetail> GetTypeDetail(int type) =>
        await _httpService.HttpRequest<TypeDetail>($"type/{type}");

    public async Task<T> GetFromUrl<T>(Uri url) =>
        await _httpService.HttpRequest<T>(url);
}
