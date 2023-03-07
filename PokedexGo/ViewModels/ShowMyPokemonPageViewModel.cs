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

public partial class ShowMyPokemonPageViewModel
{
    public List<Pokemon> Pokemons { get; set; }
    public string Name { get; set; }
    public string ImageSource { get; set; }
    public User User { get; set; }

    public ShowMyPokemonPageViewModel(User user)
    {
        User = new User
        {
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };
        if (user.Pokemons is not null)
        {
            User.Pokemons = user.Pokemons;
            Pokemons = user.Pokemons;
            Name = Pokemons.First().Name;
        }
    }
}
