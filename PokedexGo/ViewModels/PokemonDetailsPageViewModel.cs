using PokedexGo.Models;

namespace PokedexGo.ViewModels;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public class PokemonDetailsPageViewModel : ViewModelBase
{
    private Pokemon _pokemon;
    public Pokemon Pokemon
    {
        get => _pokemon;
        set => SetProperty(ref _pokemon, value);
        //set
        //{
        //    _pokemon = value;
        //    OnPropertyChanged(nameof(Pokemon));
        //}
    }
    //public PokemonDetailsPageViewModel(Pokemon pokemon)
    //{
    //    Pokemon = pokemon;
    //}
}
