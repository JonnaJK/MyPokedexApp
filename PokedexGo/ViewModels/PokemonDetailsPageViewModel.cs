using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System;

namespace PokedexGo.ViewModels;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public class PokemonDetailsPageViewModel : ViewModelBase
{
    private UserService _userService;
    private PokeService _pokeService;
    private Pokemon _pokemon;
    public Pokemon Pokemon
    {
        get => _pokemon;
        set
        {
            _pokemon = value;
            _ = Task.Run(async () => { SpeciesDetail = await _pokeService.GetFromUrl<SpeciesDetail>(_pokemon.Species.Url); });
            OnPropertyChanged(nameof(Pokemon));
        }
    }

    private SpeciesDetail _speciesDetail;
    public SpeciesDetail SpeciesDetail
    {
        get => _speciesDetail;
        set
        {
            _speciesDetail = value;
            OnPropertyChanged(nameof(SpeciesDetail));
        }
    }
    public PokemonDetailsPageViewModel()
    {
        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        // TODO: Ändra som ovan på andra ställen som använder task.wait
    }

    public async Task ChangePokemonWantedProperty(User user, int id)
    {
        var pokemon = user.Pokemons.Where(x => x.Id == id).FirstOrDefault();
        pokemon.IsWanted = !pokemon.IsWanted;
        await _userService.UpdateUserAsync(user);
    }

    public async Task ChangePokemonFavoriteProperty(User user, int id)
    {
        var pokemon = user.Pokemons.Where(x => x.Id == id).FirstOrDefault();
        pokemon.IsFavorite = !pokemon.IsFavorite;
        await _userService.UpdateUserAsync(user);
    }
}
