using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        //BindingContext = new LoginPageViewModel();
        var loginPage = new LoginPageViewModel
        {
            SignIn = new Action<User>(GoToMyPokemonPage)
        };
        BindingContext = loginPage;

        //public Action<User> SignIn { get; set; }
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void GoToMyPokemonPage(User user)
    {
        await Navigation.PushAsync(new MyPokemonPage(user));
    }

    private async void OnClickedLogIn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyPokemonPage(sender as User));
    }
}