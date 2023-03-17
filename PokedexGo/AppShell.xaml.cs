using PokedexGo.Views;

namespace PokedexGo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Pages to route to
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MyPokemonPage), typeof(MyPokemonPage));
        Routing.RegisterRoute(nameof(ShowMyPokemonPage), typeof(ShowMyPokemonPage));
        Routing.RegisterRoute(nameof(PokemonDetailsPage), typeof(PokemonDetailsPage));
        Routing.RegisterRoute(nameof(CatchEmAllPage), typeof(CatchEmAllPage));
        Routing.RegisterRoute(nameof(SearchPokemonPage), typeof(SearchPokemonPage));
        Routing.RegisterRoute(nameof(ShowMyWantedPokemonPage), typeof(ShowMyWantedPokemonPage));
    }
}