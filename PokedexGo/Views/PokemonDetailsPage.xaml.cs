namespace PokedexGo.Views;

public partial class PokemonDetailsPage : ContentPage
{
    public PokemonDetailsPage()
    {
        InitializeComponent();
    }

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("..");
}
