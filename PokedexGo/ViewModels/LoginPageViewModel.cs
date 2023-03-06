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

    //public delegate void SignIn { get; set; };
    public Action<User> SignIn { get; set; }


    public bool isLoggedIn = false;
    public bool IsLoggedIn { get; set; } = false;

    public User User { get; set; }
    public MyPokemonPageViewModel Page { get; set; }





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
        if (SignIn is not null)
        {
            SignIn.Invoke(user);
        }
        // go to page MyPokemonPage
    }

    [RelayCommand]
    public void Login()
    {
        var user = UserService.GetUser(Name, Password);
        if (user is not null)
        {
            isLoggedIn = true;
            Page = new MyPokemonPageViewModel(user);
            SignIn?.Invoke(user);
        }
    }
}
