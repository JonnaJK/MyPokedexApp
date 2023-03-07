using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    public User User { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public ShowMyPokemonPage(User user)
    {
        InitializeComponent();
        User = new User
        {
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };
        if (user.Pokemons is not null)
        {
            User.Pokemons = user.Pokemons;
            var task = Task.Run(() => GetPokemons(user));
            task.Wait();
            Pokemons = new List<Pokemon>
            {
                task.Result
            };
        }

        ListOfPokemons.ItemsSource = Pokemons;

        BindingContext = new ShowMyPokemonPageViewModel(user);
    }

    public async Task<Pokemon> GetPokemons(User user)
    {
        var pokeService = new PokeService(new HttpService());
        var pokemon = pokeService.GetPokemon("pikachu");
        //var pokeService = new PokeService(new HttpService()).GetUsersPokemons(user);

        return await pokemon;
    }
}