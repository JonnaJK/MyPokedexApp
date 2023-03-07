using PokedexGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.Services
{
    internal class PokeService
    {
        private readonly HttpService _httpService;

        public PokeService(HttpService httpService)
        {
            _httpService = new HttpService();
        }

        public async Task<List<Pokemon>> GetUsersPokemons(User user)
        {
            var list = new List<Pokemon>();
            foreach (var pokemon in user.Pokemons)
            {
                list.Add(await GetPokemon(pokemon.Name));
            }
            return list;
        }

        public async Task<Pokemon> GetPokemon(string pokemon)
        {
            return await _httpService.HttpRequest<Pokemon>($"pokemon/{pokemon}");
        }

        public async Task<Pokemon> GetType(int type)
        {
            return await _httpService.HttpRequest<Pokemon>($"type/{type}");
        }
    }
}
