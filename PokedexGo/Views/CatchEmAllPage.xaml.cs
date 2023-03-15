using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class CatchEmAllPage : ContentPage
{
	public CatchEmAllPage(CatchEmAllPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Navigation.PopAsync();
}