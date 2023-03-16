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
    private string _imageSource;
    private string _flavorTexLabel;
    #endregion

    #region Properties
    public string ImageSource
    {
        get => _imageSource;
        set
        {
            _imageSource = value;
            OnPropertyChanged(nameof(ImageSource));
        }
    }
    public Pokemon Pokemon
    {
        get => _pokemon;
        set
        {
            _pokemon = value;
            _ = Task.Run(async () => { SpeciesDetail = await _pokeService.GetFromUrl<SpeciesDetail>(_pokemon.Species.Url); });
            _ = Task.Run(() => { ImageSource = _pokemon.IsFavorite ? "favorite.png" : "notfavorite.png"; });
            OnPropertyChanged(nameof(Pokemon));
        }
    }
    public SpeciesDetail SpeciesDetail
    {
        get => _speciesDetail;
        set
        {
            _speciesDetail = value;
            _ = Task.Run(() => { FlavorTextLabel = SpeciesDetail.FlavorTextEntries.Where(x => x.Language.Name == "en").FirstOrDefault().FlavorText; });
            OnPropertyChanged(nameof(SpeciesDetail));
        }
    }
    public string FlavorTextLabel
    {
        get => _flavorTexLabel;
        set
        {
            _flavorTexLabel = value;
            OnPropertyChanged(nameof(FlavorTextLabel));
        }
    }
    public ICommand ToggleFavoriteCommand { get; private set; }
    public ICommand ToggleWantedCommand { get; private set; }
    public ICommand RemoveCommand { get; private set; }
    public ICommand GetEnFlavorTextCommand { get; private set; }
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


    public string GetEnFlavorText() =>
        SpeciesDetail.FlavorTextEntries.Where(x => x.Language.Name == "en").FirstOrDefault().FlavorText;

    #region Commands
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

    public async Task ToggleIsFavorite()
    {
        // Change heart image source
        ImageSource = Pokemon.IsFavorite ? "favorite.png" : "notfavorite.png";

        Pokemon.IsFavorite = !Pokemon.IsFavorite;
        OnPropertyChanged(nameof(Pokemon));

        _user.Pokemon.FindAll(x => x.Name == Pokemon.Name.ToLower()).ForEach(x => x.IsFavorite = Pokemon.IsFavorite);

        if (Pokemon.IsFavorite)
            _user.FavoritePokemon.Add(new Pokemon
            {
                Name = Pokemon.Name.ToLower(),
                IsFavorite = Pokemon.IsFavorite,
                IsWanted = Pokemon.IsWanted
            });
        else
            _user.FavoritePokemon.Remove(_user.FavoritePokemon.Find(x => x.Name == Pokemon.Name.ToLower()));

        await _userService.UpdateUserAsync(_user);
    }
    #endregion

    // TODO: Move to page wantedpokemons
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
}
