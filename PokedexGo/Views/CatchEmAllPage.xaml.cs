using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class CatchEmAllPage : ContentPage
{
	public CatchEmAllPage()
	{
		InitializeComponent();
	}

    private async void OnClickedGoBack(object sender, EventArgs e) =>
        await Navigation.PopAsync();
}