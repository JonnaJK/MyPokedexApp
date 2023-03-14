using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;

namespace PokedexGo.ViewModels;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public class PokemonDetailsPageViewModel : ViewModelBase
{
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private Pokemon _pokemon;
    public Pokemon Pokemon
    {
        get => _pokemon;
        set
        {
            _pokemon = value;
            // TODO: Ändra som ovan på andra ställen som använder task.wait
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

    public ICommand ChangeFavoritePropertyCommand { get; set; }
    public ICommand ChangeWantedPropertyCommand { get; set; }

    public PokemonDetailsPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        ChangeFavoritePropertyCommand = new Command(async () => await ChangePokemonFavoriteProperty());
        ChangeWantedPropertyCommand = new Command(async () => await ChangePokemonWantedProperty());
    }

    public async Task ChangePokemonWantedProperty()
    {
        var pokemons = await _pokeService.GetUsersPokemons(_user);
        var pokemon = pokemons.Where(x => x.Id == _pokemon.Id).FirstOrDefault();
        pokemon.IsWanted = !pokemon.IsWanted;
        await _userService.UpdateUserAsync(_user);
    }

    public async Task ChangePokemonFavoriteProperty()
    {
        var pokemons = await _pokeService.GetUsersPokemons(_user);
        var pokemon = pokemons.Where(x => x.Id == _pokemon.Id).FirstOrDefault();
        pokemon.IsFavorite = !pokemon.IsFavorite;
        _user.Pokemons = pokemons;

        if (_user.FavoritePokemons is not null)
            _user.FavoritePokemons.Add(pokemon);
        else
            _user.FavoritePokemons = new()
            {
                pokemon
            };

        await _userService.UpdateUserAsync(_user);
    }
}
