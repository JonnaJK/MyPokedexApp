using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class LoginPage : ContentPage
{

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Navigation.PopAsync();

    private async void GoToMyPokemonPage(User user) =>
        await Navigation.PushAsync(new MyPokemonPage());
}