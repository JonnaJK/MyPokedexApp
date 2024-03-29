﻿using PokedexGo.Views;

namespace PokedexGo;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnClickedGoLoginPage(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync(nameof(LoginPage));
}