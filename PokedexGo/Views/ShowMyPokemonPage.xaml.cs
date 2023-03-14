using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    private User _user;

    public ShowMyPokemonPage()
    {
        InitializeComponent();
        _user = ServiceHelper.GetService<User>();
    }

    public static async Task<Pokemon> GetPokemon(string pokemonName)
    {
        var pokeService = new PokeService();
        var pokemon = pokeService.GetOnePokemon(pokemonName);

        return await pokemon;
    }
}