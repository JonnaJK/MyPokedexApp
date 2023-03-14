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

        _user.Pokemons.Where(x => x.Name == pokemon.Name).ToList().ForEach(x => x.IsWanted = !x.IsWanted);
        Pokemon.IsWanted = pokemon.IsWanted;

        if (_user.WantedPokemons is not null)
        {
            if (pokemon.IsWanted)
                _user.WantedPokemons.Add(new Pokemon { Name = pokemon.Name, IsFavorite = pokemon.IsFavorite, IsWanted = pokemon.IsWanted });
            else
            {
                var pokemonToRemove = _user.WantedPokemons.Where(x => x.Name == pokemon.Name).FirstOrDefault();
                _user.WantedPokemons.Remove(pokemonToRemove);
            }
        }
        else
        {
            _user.WantedPokemons = new()
            {
                //pokemon
                new Pokemon { Name = pokemon.Name, IsFavorite = pokemon.IsFavorite, IsWanted = pokemon.IsWanted }
            };
        }
        OnPropertyChanged(nameof(Pokemon));

        await _userService.UpdateUserAsync(_user);
    }

    public async Task ChangePokemonFavoriteProperty()
    {
        var pokemons = await _pokeService.GetUsersPokemons(_user);
        var pokemon = pokemons.Where(x => x.Id == _pokemon.Id).FirstOrDefault();
        pokemon.IsFavorite = !pokemon.IsFavorite;

        _user.Pokemons.Where(x => x.Name == pokemon.Name).ToList().ForEach(x => x.IsFavorite = !x.IsFavorite);
        Pokemon.IsFavorite = pokemon.IsFavorite;

        if (_user.FavoritePokemons is not null)
        {
            if (pokemon.IsFavorite)
                _user.FavoritePokemons.Add(new Pokemon { Name = pokemon.Name, IsFavorite = pokemon.IsFavorite, IsWanted = pokemon.IsWanted });
            else
            {
                var pokemonToRemove = _user.FavoritePokemons.Where(x => x.Name == pokemon.Name).FirstOrDefault();
                _user.FavoritePokemons.Remove(pokemonToRemove);
            }
        }
        else
        {
            _user.FavoritePokemons = new()
            {
                //pokemon
                new Pokemon { Name = pokemon.Name, IsFavorite = pokemon.IsFavorite, IsWanted = pokemon.IsWanted }
            };
        }
        OnPropertyChanged(nameof(Pokemon));

        await _userService.UpdateUserAsync(_user);
    }
}
