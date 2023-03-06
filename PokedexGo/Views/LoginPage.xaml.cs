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

    private async void OnClickedRegisterNewUser(object sender, EventArgs e)
    {
        var user = new User
        {
            Id = new Guid(),
            Name = Name.Text,
            Password = Password.Text
        };
        await UserService.SaveUser(user); 
    }
}