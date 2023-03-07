using CommunityToolkit.Mvvm.ComponentModel;
using PokedexGo.Models;
using PokedexGo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.ViewModels;

public partial class ShowMyPokemonPageViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Pokemon> pokemons;

    public ShowMyPokemonPageViewModel(User user)
    {
        pokemons = new ObservableCollection<Pokemon>();
        var task = Task.Run(() =>  PokeService.GetAllPokemons(user));
        task.Wait();
        for (int i = 0; i < task.Result.Count; i++)
        {
            pokemons.Add(task.Result[i]);
        }
    }
}
