using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;

namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    private User _user;
    //public List<Pokemon> Pokemons { get; set; }

    public ShowMyPokemonPage()
    {
        InitializeComponent();
        _user = ServiceHelper.GetService<User>();

        // faktiskt hämtar pokemon från api med all information
        //var pokeService = new PokeService();
        //var task = Task.Run(() => pokeService.GetUsersPokemons(_user));
        //task.Wait();
        //Pokemons = task.Result.ToList();

        //ListOfPokemons.ItemsSource = Pokemons;
    }

    public static async Task<Pokemon> GetPokemon(string pokemonName)
    {
        var pokeService = new PokeService();
        var pokemon = pokeService.GetOnePokemon(pokemonName);
        //var pokeService = new PokeService(new HttpService()).GetUsersPokemons(user);

        return await pokemon;
    }

    private async void OnItemSelectedGoToPokemonDetailsPage(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new PokemonDetailsPage((GetPokemon((e.SelectedItem as Pokemon).Name)).Result));
    }
}