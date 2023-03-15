using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class PokemonDetailsPage : ContentPage
{
    public PokemonDetailsPage(PokemonDetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("..");
}
