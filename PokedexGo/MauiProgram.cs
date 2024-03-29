﻿using Microsoft.Extensions.Configuration;
using PokedexGo.Facades;
using PokedexGo.Interfaces;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Settings;
using PokedexGo.ViewModels;
using PokedexGo.Views;
using System.Reflection;

namespace PokedexGo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Skapar en configuration för att enklare kunna använda databas options när jag ska connecta med min databas på MongoDB.
        // På detta sätt behöver jag endast ändra i appsettings.json
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("PokedexGo.appsettings.json");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        builder.Configuration.AddConfiguration(config);
        builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));

        // Använder desing patterns Dependency Injection och Singleton för att enkelt instansiera en class/objekt och använda instans oavsett vart man är i applikationen.
        // (eller Transient, som inte räknas som design pattern men vill nämna ändå, om jag vill ha en ny instans av objektet.

        // Adderar Singleton för de klasser som endast ska instansieras en gång och sparas i minnet, exempelvis PokeService och AlertService för att spara minne och återanvända samma instans.
        // Valde att ha det på User för att när man är inloggad så ska samma instans av User och dess property användas på alla sidor

        // Adderar Transient för de klasser som ska skapas upp endast när de används och sedan "skrotas"
        // Valde att ha det på UserService för att det inte behövs en och samma instans av det objektet, dvs. behöver inte ta upp minne förutom när man behöver göra ett anrop till databasen
        
        // Services - Singleton
        builder.Services.AddSingleton<PokeService>();
        builder.Services.AddSingleton<AlertService>();
        // Bättre med transient men eftersom det är en mobilapplikation och man egentligen bör prata med sin databas via ett api så valde jag att ha HttpService som singleton
        builder.Services.AddSingleton<HttpService>();
        // Services - Transient
        builder.Services.AddTransient<UserService>();
        builder.Services.AddTransient<ILoginFacade, LoginFacade>();
        builder.Services.AddTransient<IRegisterNewUserFacade, RegisterNewUserFacade>();

        // Models - Singleton
        builder.Services.AddSingleton<User>();

        // Views - Transient
        builder.Services.AddTransient<MyPokemonPage>();
        builder.Services.AddTransient<PokemonDetailsPage>();
        builder.Services.AddTransient<ShowMyPokemonPage>();
        builder.Services.AddTransient<CatchEmAllPage>();
        builder.Services.AddTransient<SearchPokemonPage>();
        builder.Services.AddTransient<ShowMyWantedPokemonPage>();
        // Views - Singleton

        // View Models - Transient
        builder.Services.AddTransient<MyPokemonPageViewModel>();
        builder.Services.AddTransient<ShowMyPokemonPageViewModel>();
        builder.Services.AddTransient<PokemonDetailsPageViewModel>();
        builder.Services.AddTransient<CatchEmAllPageViewModel>();
        builder.Services.AddTransient<SearchPokemonPageViewModel>();
        builder.Services.AddTransient<ShowMyWantedPokemonPageViewModel>();

        return builder.Build();
    }
}