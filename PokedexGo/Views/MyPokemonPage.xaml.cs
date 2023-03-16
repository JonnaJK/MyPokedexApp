using PokedexGo.Models;

namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{

    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }

    public MyPokemonPage()
    {
        InitializeComponent();
    }

    private async void OnClickedLogOut(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync($"..");
}