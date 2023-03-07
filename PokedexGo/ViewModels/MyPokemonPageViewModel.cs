using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokedexGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.ViewModels;

public partial class MyPokemonPageViewModel : ObservableObject
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    List<Pokemon> pokemons;
    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }

    public MyPokemonPageViewModel(User user)
    {
        Name = user.Name;
        Password = user.Password;
        if (user.Pokemons is not null)
        {
            Pokemons = user.Pokemons;
        }
    }

    // TODO: Not working, why???
    [RelayCommand]
    public void ShowMyPokemonCommand()
    {
        // go to show my pokemon page
        GoToShowMyPokemonPage?.Invoke(Pokemons);
    }
}
