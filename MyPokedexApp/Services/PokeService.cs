using MyPokedexApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPokedexApp.Services;

public class PokeService
{
    //private readonly HttpService _httpService;

    public PokeService(HttpService httpService)
    {
        //_httpService = httpService;
    }

    public async Task<Pokemon> GetPokemon(string pokemon)
    {
        return null;
        //return await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemon}");
    }

    public async Task<Pokemon> GetType(int type)
    {
        return null;
        //return await _httpService.HttpRequest<Pokemon>($"type/{type}");
    }
}
