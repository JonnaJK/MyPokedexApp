using CommunityToolkit.Mvvm.ComponentModel;
using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.ViewModels;

public partial class ShowMyPokemonPageViewModel : ViewModelBase
{
    private User _user;

    public ShowMyPokemonPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
    }

    public void OnPokemonSelected()
    {

    }
}
