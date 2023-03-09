using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class LoginPage : ContentPage
{
    private User _user;

    public LoginPage()
    {
        InitializeComponent();

        // TODO: Förklara vad GetService gör
        _user = ServiceHelper.GetService<User>();

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
        await Navigation.PushAsync(new MyPokemonPage());
    }
}