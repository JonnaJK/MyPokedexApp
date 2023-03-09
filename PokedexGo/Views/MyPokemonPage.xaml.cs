using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{
    private User _user;

    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }

    public MyPokemonPage()
    {
        _user = ServiceHelper.GetService<User>();
        InitializeComponent();
        // TODO: Not working, why???
        var myPokemonPage = new MyPokemonPageViewModel()
        {
            GoToShowMyPokemonPage = new Action<List<Pokemon>>(GoToShowMyPokemonsPage)
        };
        BindingContext = myPokemonPage;
    }

    private async void OnClickedLogOut(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void GoToShowMyPokemonsPage(List<Pokemon> pokemons)
    {
        await Navigation.PushAsync(new ShowMyPokemonPage());
    }
}