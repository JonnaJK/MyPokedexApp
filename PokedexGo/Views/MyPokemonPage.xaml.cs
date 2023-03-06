using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class MyPokemonPage : ContentPage
{
	public MyPokemonPage(User user)
	{
		InitializeComponent();
		BindingContext = new MyPokemonPageViewModel(user);
	}
}