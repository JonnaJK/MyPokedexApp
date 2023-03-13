using PokedexGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        return list;
    }

    public async Task<Pokemon> GetOnePokemon(string pokemon) =>
        await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemon}");

    public async Task<Pokemon> GetType(int type) =>
        await _httpService.HttpRequest<Pokemon>($"type/{type}");

    public async Task<T> GetFromUrl<T>(Uri url) =>
        await _httpService.HttpRequest<T>(url);
}
