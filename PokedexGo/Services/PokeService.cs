using PokedexGo.Models;

namespace PokedexGo.Services;

internal class PokeService
{
    private readonly HttpService _httpService;

    public PokeService()
    {
        _httpService = new HttpService();
    }

    public async Task<List<Pokemon>> GetUsersPokemons(User user)
    {
        var list = new List<Pokemon>();
        foreach (var pokemon in user.Pokemons)
        {
            list.Add(await GetOnePokemon(pokemon.Name));
            if (pokemon.IsWanted)
                list.Where(x => x.Name == pokemon.Name).FirstOrDefault().IsWanted = true;
            if (pokemon.IsFavorite)
                list.Where(x => x.Name == pokemon.Name).ToList().ForEach(x => x.IsFavorite = true);
        }
        return list;
    }

    public async Task<Pokemon> GetOnePokemon(string pokemonName) =>
        await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemonName}");

    public async Task<Pokemon> GetType(int type) =>
        await _httpService.HttpRequest<Pokemon>($"type/{type}");

    public async Task<T> GetFromUrl<T>(Uri url) =>
        await _httpService.HttpRequest<T>(url);
}
