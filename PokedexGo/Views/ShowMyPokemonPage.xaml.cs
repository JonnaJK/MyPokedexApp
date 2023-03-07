using PokedexGo.Models;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    public User User { get; set; }

    public ShowMyPokemonPage(User user)
	{
		InitializeComponent();
        User = new User
        {
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };
        if (user.Pokemons is not null)
        {
            User.Pokemons = user.Pokemons;
        }
        BindingContext = new ShowMyPokemonPageViewModel(user);
	}
}