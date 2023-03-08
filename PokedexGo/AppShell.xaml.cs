﻿using PokedexGo.Views;

namespace PokedexGo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MyPokemonPage), typeof(MyPokemonPage));
        Routing.RegisterRoute(nameof(PokemonDetailsPage), typeof(PokemonDetailsPage));
        Routing.RegisterRoute(nameof(ShowMyPokemonPage), typeof(ShowMyPokemonPage));
    }
}