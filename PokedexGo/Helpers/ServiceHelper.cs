﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexGo.Helpers;

public static class ServiceHelper
{
    public static T GetService<T>()
        => Current.GetService<T>();

    // Hämtar 
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
