using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{

    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }

    public MyPokemonPage()
    {
        InitializeComponent();
        // TODO: NEW. Not working, why??? Ta bort??
        var myPokemonPage = new MyPokemonPageViewModel()
        {
            GoToShowMyPokemonPage = new Action<List<Pokemon>>(GoToShowMyPokemonsPage)
        };
        BindingContext = myPokemonPage;
    }

    private async void OnClickedLogOut(object sender, EventArgs e) =>
        await Navigation.PopAsync();

    private async void GoToShowMyPokemonsPage(List<Pokemon> pokemons) =>
        await Navigation.PushAsync(new ShowMyPokemonPage());

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Navigation.PopAsync();
}