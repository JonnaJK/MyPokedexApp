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
    }

    private async void OnClickedLogOut(object sender, EventArgs e) =>
        await Navigation.PopAsync();

    private async void GoToShowMyPokemonsPage(List<Pokemon> pokemon) =>
        await Navigation.PushAsync(new ShowMyPokemonPage());
}