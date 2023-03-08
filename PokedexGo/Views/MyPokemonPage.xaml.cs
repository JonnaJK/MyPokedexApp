using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{
    public User User { get; set; }

    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }

    public MyPokemonPage(User user)
    {
        InitializeComponent();
        User = new User
        {
            Id = user.Id,
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };
        if (user.Pokemons is not null)
        {
            User.Pokemons = user.Pokemons;
        }
        // TODO: Not working, why???
        var myPokemonPage = new MyPokemonPageViewModel()
        {
            GoToShowMyPokemonPage = new Action<List<Pokemon>>(GoToShowMyPokemonsPage)
        };
        BindingContext = myPokemonPage;
        welcomeText.Text = $"Welcome {user.UserName}!";
    }

    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void GoToShowMyPokemonsPage(List<Pokemon> pokemons)
    {
        await Navigation.PushAsync(new ShowMyPokemonPage(User));
    }

    private async void OnClickedGoToShowMyPokemonPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShowMyPokemonPage(User));
    }
}