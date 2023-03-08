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
            //user.Pokemons.Add(new Pokemon { Name = "diglett" });
            //var taskTest = Task.Run(() => UserService.AddPokemonToUser(user, new Pokemon { Name = "diglett" }));
            //taskTest.Wait();
            
            User.Pokemons = user.Pokemons;
            var pokeService = new PokeService(new HttpService());
            var task = Task.Run(() => pokeService.GetUsersPokemons(user));
            task.Wait();
            Pokemons = new List<Pokemon>();
            foreach (var pokemon in task.Result)
            {
                Pokemons.Add(pokemon);
            }
            //var task = Task.Run(() => GetPokemons(user));
            //task.Wait();
            //Pokemons = new List<Pokemon>
            //{
            //    task.Result
            //};
        }

        ListOfPokemons.ItemsSource = Pokemons;

        BindingContext = new ShowMyPokemonPageViewModel(user);
    }

    public static async Task<Pokemon> GetPokemon(string pokemonName)
    {
        var pokeService = new PokeService(new HttpService());
        var pokemon = pokeService.GetOnePokemon(pokemonName);
        //var pokeService = new PokeService(new HttpService()).GetUsersPokemons(user);

        return await pokemon;
    }

    private async void OnItemSelectedGoToPokemonDetailsPage(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new PokemonDetailsPage( (GetPokemon( (e.SelectedItem as Pokemon).Name )).Result ) );
    }
}