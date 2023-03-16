namespace PokedexGo.Views;

public partial class ShowMyWantedPokemonPage : ContentPage
{
	public ShowMyWantedPokemonPage()
	{
		InitializeComponent();
	}

	private async void OnClickedGoBack(object sender, EventArgs e) =>
		await Shell.Current.GoToAsync("..");
}