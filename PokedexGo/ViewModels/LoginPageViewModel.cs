using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokedexGo.Models;
using PokedexGo.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PokedexGo.ViewModels;

partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    Guid id;
    [ObservableProperty]
    string name;
    [ObservableProperty]
    List<Pokemon> pokemons;
}
