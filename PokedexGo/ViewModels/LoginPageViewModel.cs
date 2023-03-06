using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokedexGo.Models;
using PokedexGo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PokedexGo.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    Guid id;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    List<Pokemon> pokemons;

    [RelayCommand]
    public async void RegisterNewUser()
    {
        var user = new User
        {
            Id = new Guid(),
            Name = Name,
            Password = Password
        };
        await UserService.SaveUser(user);
    }

    [RelayCommand]
    public async void Login()
    {
        var user = UserService.GetUser(Name);
        if (user is not null)
        {

        }
    }
}
