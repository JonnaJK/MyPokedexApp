namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{
    public MyPokemonPage()
    {
        InitializeComponent();
    }

    private async void OnClickedLogOut(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync($"..");
}