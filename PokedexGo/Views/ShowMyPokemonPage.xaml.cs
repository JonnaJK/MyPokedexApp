using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    public ShowMyPokemonPage(ShowMyPokemonPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Navigation.PopAsync();
}