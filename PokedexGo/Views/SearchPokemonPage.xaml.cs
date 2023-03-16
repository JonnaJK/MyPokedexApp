using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class SearchPokemonPage : ContentPage
{
	public SearchPokemonPage(SearchPokemonPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("..");
}