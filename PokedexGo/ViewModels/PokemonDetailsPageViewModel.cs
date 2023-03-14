using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PokedexGo.Views;

namespace PokedexGo.ViewModels;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public class PokemonDetailsPageViewModel : ViewModelBase
{
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private Pokemon _pokemon;
    private AlertService _alertService;
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
    #region Commands
    public ICommand ToggleFavoriteCommand { get; set; }
    public ICommand ToggleWantedCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    #endregion

    public PokemonDetailsPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _userService = ServiceHelper.GetService<UserService>();
        _pokeService = ServiceHelper.GetService<PokeService>();
        _alertService = ServiceHelper.GetService<AlertService>();

        ToggleFavoriteCommand = new Command(async () => await ToggleIsFavorite());
        ToggleWantedCommand = new Command(async () => await ToggleIsWanted());
        RemoveCommand = new Command(async () => await RemovePokemon());
    }

    private async Task RemovePokemon()
    {
        var answer = await _alertService.ShowConfirmationAsync("Warning", "Are you sure that you want to remove this pokemon?", "Yes", "No");
        if (answer)
        {
            var pokemon = _user.Pokemons.Find(x => x.Name == _pokemon.Name.ToLower());
            _user.Pokemons.Remove(pokemon);
            await _userService.UpdateUserAsync(_user);
            await Shell.Current.GoToAsync(nameof(ShowMyPokemonPage));
        }
    }

    public async Task ToggleIsWanted()
    {
        Pokemon.IsWanted = !Pokemon.IsWanted;
        OnPropertyChanged(nameof(Pokemon));

        _user.Pokemons.FindAll(x => x.Name == Pokemon.Name.ToLower()).ForEach(x => x.IsWanted = Pokemon.IsWanted);

        if (Pokemon.IsWanted)
            _user.WantedPokemons.Add(new Pokemon { Name = Pokemon.Name.ToLower(), IsFavorite = Pokemon.IsFavorite, IsWanted = Pokemon.IsWanted });
        else
            _user.WantedPokemons.Remove(_user.WantedPokemons.Find(x => x.Name == Pokemon.Name.ToLower()));

        await _userService.UpdateUserAsync(_user);
    }

    public async Task ToggleIsFavorite()
    {
        Pokemon.IsFavorite = !Pokemon.IsFavorite;
        OnPropertyChanged(nameof(Pokemon));

        _user.Pokemons.FindAll(x => x.Name == Pokemon.Name.ToLower()).ForEach(x => x.IsFavorite = Pokemon.IsFavorite);

        if (Pokemon.IsFavorite)
            _user.FavoritePokemons.Add(new Pokemon { Name = Pokemon.Name.ToLower(), IsFavorite = Pokemon.IsFavorite, IsWanted = Pokemon.IsWanted });
        else
            _user.FavoritePokemons.Remove(_user.FavoritePokemons.Find(x => x.Name == Pokemon.Name.ToLower()));

        await _userService.UpdateUserAsync(_user);
    }
}
