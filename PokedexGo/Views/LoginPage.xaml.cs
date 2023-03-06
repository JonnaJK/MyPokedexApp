using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
	}

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private void OnClickedLogIn(object sender, EventArgs e)
    {
        var user = sender as User;

    }
}