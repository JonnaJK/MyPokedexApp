using PokedexGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.ViewModels;

internal class PokemonDetailsPageViewModel : ViewModelBase
{
    public Pokemon Pokemon { get; set; }
}
