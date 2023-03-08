using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class PokemonDetailsPage : ContentPage
{
    public new int Id { get; set; }
    public string Asdasd { get; set; }
    public int BaseExperience { get; set; }
    public new int Height { get; set; }
    public int Weight { get; set; }
    public Pokemon Pokemon { get; set; }
    public PokemonDetailsPage(Pokemon pokemon)
	{
        Id = pokemon.Id;
        Asdasd = pokemon.Name;
        BaseExperience = pokemon.BaseExperience;
        Height = pokemon.Height;
        Weight = pokemon.Weight;


		Pokemon = pokemon;
		InitializeComponent();
		BindingContext = new PokemonDetailsPageViewModel();
	}
}