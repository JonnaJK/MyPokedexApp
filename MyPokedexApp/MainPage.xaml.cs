using MyPokedexApp.Services;

namespace MyPokedexApp;

public partial class MainPage : ContentPage
{
	private readonly PokeService _pokeService;

	//int count = 0;

	public MainPage(PokeService pokeService)
	{
		InitializeComponent();
		_pokeService = pokeService;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void OnClickedGetPokemon(object sender, EventArgs e)
    {
		try
		{
			var pokemon = _pokeService.GetPokemon("pikachu");
		}
		catch (Exception)
		{
		}
    }
}

