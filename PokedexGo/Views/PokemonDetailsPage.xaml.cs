using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class PokemonDetailsPage : ContentPage
{
    //private Pokemon _pokemon;
    //public Pokemon Pokemon
    //{

    //    get => _pokemon;
    //    set
    //    {
    //        _pokemon = value;
    //        OnPropertyChanged(nameof(Pokemon));
    //    }
    //}

    public PokemonDetailsPage(PokemonDetailsPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
