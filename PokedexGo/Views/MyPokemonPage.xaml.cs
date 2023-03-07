using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{
	public MyPokemonPage(User user)
	{
		InitializeComponent();
        // TODO: Not working, why???
        var myPokemonPage = new MyPokemonPageViewModel(user)
        {
            GoToShowMyPokemonPage = new Action<List<Pokemon>>(GoToShowMyPokemonPage)
        };
        BindingContext = myPokemonPage;
		welcomeText.Text = $"Welcome {user.UserName}!";
    }

    private async void OnClickedLogOut(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void GoToShowMyPokemonPage(List<Pokemon> pokemons)
    {
        await Navigation.PushAsync(new ShowMyPokemonPage());
    }

    private async void OnClickedGoToShowMyPokemonPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShowMyPokemonPage());
    }
}