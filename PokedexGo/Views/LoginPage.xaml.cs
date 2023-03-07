using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class LoginPage : ContentPage
{
    public User User { get; set; }

    public LoginPage()
    {
        InitializeComponent();
        var loginPage = new LoginPageViewModel
        {
            SignedIn = new Action<User>(GoToMyPokemonPage)
        };
        BindingContext = loginPage;
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void GoToMyPokemonPage(User user)
    {
        await Navigation.PushAsync(new MyPokemonPage(user));
    }

    private async void OnClickedGoToMyPokemonPage(object sender, EventArgs e)
    {
        User = UserService.GetUser(UserName.Text, UserPassword.Text);
        if (User is not null)
            await Navigation.PushAsync(new MyPokemonPage(User));
    }

    private async void OnClickedRegisterNewUser(object sender, EventArgs e)
    {
        User = new User
        {
            Id = new Guid(),
            UserName = UserName.Text,
            UserPassword = UserPassword.Text,
            // TODO: Ta bort testdata
            Pokemons = new List<Pokemon>{ new Pokemon { Name = "pikachu" } }
        };
        await UserService.SaveUser(User);
        await Navigation.PushAsync(new MyPokemonPage(User));
    }
}