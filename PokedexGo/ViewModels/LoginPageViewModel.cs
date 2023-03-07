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
using PokedexGo.Views;

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

    public Action<User> SignedIn { get; set; }

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
        SignedIn?.Invoke(user);
    }

    [RelayCommand]
    public void Login()
    {
        var user = UserService.GetUser(Name, Password);
        if (user is not null)
            SignedIn?.Invoke(user);
        // TODO: Could not find user in db
    }
}
