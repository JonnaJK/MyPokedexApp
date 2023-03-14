using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;

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
        var pokemon = pokeService.GetPokemonByName(pokemonName);

        return await pokemon;
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}