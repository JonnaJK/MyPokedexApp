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

public partial class LoginPageViewModel
{
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public User User { get; set; }

    public Action<User> SignedIn { get; set; }

    //public async void RegisterNewUser()
    //{
    //    User = new User
    //    {
    //        Id = new Guid(),
    //        UserName = UserName,
    //        UserPassword = UserPassword
    //    };
    //    await UserService.SaveUser(User);
    //    SignedIn?.Invoke(User);
    //}

    public void Login()
    {
        User = UserService.GetUser(UserName, UserPassword);
        if (User is not null)
            SignedIn?.Invoke(User);
        // TODO: Could not find user in db
    }
}
