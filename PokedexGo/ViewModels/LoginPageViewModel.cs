﻿using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Views;
using System.Windows.Input;
using PokedexGo.Helpers;

namespace PokedexGo.ViewModels;

public partial class LoginPageViewModel : ViewModelBase
{
    private User _user;
    private UserService _userService;

    private string _userName;
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }
    private string _userPassword;
    public string UserPassword
    {
        get => _userPassword;
        set
        {
            _userPassword = value;
            OnPropertyChanged(nameof(UserPassword));
        }
    }

    public List<Pokemon> Pokemons { get; set; }
    public Action<User> SignedIn { get; set; }
    public ICommand LoginCommand { get; private set; }
    public ICommand RegisterNewUserCommand { get; private set; }

    public LoginPageViewModel()
    {
        _user = ServiceHelper.GetService<User>();
        _userService = ServiceHelper.GetService<UserService>();
        LoginCommand = new Command(async () => await Login());
        RegisterNewUserCommand = new Command(async () => await RegisterNewUser());
    }

    public async Task Login()
    {
        var user = await _userService.GetUserAsync(UserName, UserPassword);
        if (user is not null)
        {
            _user.Id = user.Id;
            _user.UserName = user.UserName;
            _user.UserPassword = user.UserPassword;
            _user.Pokemons = user.Pokemons;

            // TODO: This should work...
            //EntryUserName.Text = string.Empty;
            //EntryPassword.Text = string.Empty;

            await Shell.Current.GoToAsync(nameof(MyPokemonPage));
        }
    }
    // TODO: Randomisa sin starter pokemon!! 1% för pikachu, 33 för charmander, 33 för bulbasaur, 33 för squirtle

    public async Task RegisterNewUser()
    {
        _user.Id = new Guid();
        _user.UserName = UserName;
        _user.UserPassword = UserPassword;
        // TODO: Ta bort testdata
        _user.Pokemons = new List<Pokemon> { new Pokemon { Name = "pikachu" } };

        await _userService.CreateUserAsync(_user);
        await Shell.Current.GoToAsync(nameof(MyPokemonPage));
    }
}
