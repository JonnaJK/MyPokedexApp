using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System.Windows.Input;
using PokedexGo.Views;

namespace PokedexGo.ViewModels;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public class PokemonDetailsPageViewModel : ViewModelBase
{
    #region Attributes
    private User _user;
    private UserService _userService;
    private PokeService _pokeService;
    private AlertService _alertService;
    private Pokemon _pokemon;
    private SpeciesDetail _speciesDetail;
    #endregion

    #region Properties
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
    public SpeciesDetail SpeciesDetail
    {
        get => _speciesDetail;
        set
        {
            _speciesDetail = value;
            OnPropertyChanged(nameof(SpeciesDetail));
        }
    }
    public ICommand ToggleFavoriteCommand { get; private set; }
    public ICommand ToggleWantedCommand { get; private set; }
    public ICommand RemoveCommand { get; private set; }
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
            var pokemon = _user.Pokemon.Find(x => x.Name == _pokemon.Name.ToLower());
            _user.Pokemon.Remove(pokemon);
            await _userService.UpdateUserAsync(_user);
            await Shell.Current.GoToAsync(nameof(ShowMyPokemonPage));
        }
    }

    public async Task ToggleIsWanted()
    {
        Pokemon.IsWanted = !Pokemon.IsWanted;
        OnPropertyChanged(nameof(Pokemon));

        _user.Pokemon.FindAll(x => x.Name == Pokemon.Name.ToLower()).ForEach(x => x.IsWanted = Pokemon.IsWanted);

        if (Pokemon.IsWanted)
            _user.WantedPokemon.Add(new Pokemon { Name = Pokemon.Name.ToLower(), IsFavorite = Pokemon.IsFavorite, IsWanted = Pokemon.IsWanted });
        else
            _user.WantedPokemon.Remove(_user.WantedPokemon.Find(x => x.Name == Pokemon.Name.ToLower()));

        await _userService.UpdateUserAsync(_user);
    }

    public async Task ToggleIsFavorite()
    {
        Pokemon.IsFavorite = !Pokemon.IsFavorite;
        OnPropertyChanged(nameof(Pokemon));

        _user.Pokemon.FindAll(x => x.Name == Pokemon.Name.ToLower()).ForEach(x => x.IsFavorite = Pokemon.IsFavorite);

        if (Pokemon.IsFavorite)
            _user.FavoritePokemon.Add(new Pokemon { Name = Pokemon.Name.ToLower(), IsFavorite = Pokemon.IsFavorite, IsWanted = Pokemon.IsWanted });
        else
            _user.FavoritePokemon.Remove(_user.FavoritePokemon.Find(x => x.Name == Pokemon.Name.ToLower()));

        await _userService.UpdateUserAsync(_user);
    }
}
