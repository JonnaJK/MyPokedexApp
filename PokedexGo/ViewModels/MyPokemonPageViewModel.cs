using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokedexGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.ViewModels;

public partial class MyPokemonPageViewModel : ViewModelBase
{
    public User User { get; set; }

    public Action<List<Pokemon>> GoToShowMyPokemonPage { get; set; }


    // TODO: Not working, why???
    //[RelayCommand]
    //public void ShowMyPokemonCommand()
    //{
    //    // go to show my pokemon page
    //    GoToShowMyPokemonPage?.Invoke(Pokemons);
    //}
}
