﻿namespace PokedexGo.Helpers;

public static class ServiceHelper
{
    public static T GetService<T>()
        => Current.GetService<T>();

    // TODO: NEW Skriv en tydlig kommentar om vad detta gör.
    // Hämtar service för rätt plattform
    public static IServiceProvider Current =>
    #if WINDOWS10_0_17763_0_OR_GREATER
        MauiWinUIApplication.Current.Services;
    #elif ANDROID
        MauiApplication.Current.Services;
    #elif IOS || MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
    #else
        null;
    #endif
}
