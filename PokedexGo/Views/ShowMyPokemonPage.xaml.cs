namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    public ShowMyPokemonPage()
    {
        InitializeComponent();
    }

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("..");
}