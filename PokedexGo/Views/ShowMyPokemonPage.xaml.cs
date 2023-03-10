using PokedexGo.Helpers;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.ViewModels;

namespace PokedexGo.Views;

public partial class ShowMyPokemonPage : ContentPage
{
    private User _user;
    //public List<Pokemon> Pokemons { get; set; }

    public ShowMyPokemonPage()
    {
        InitializeComponent();
        _user = ServiceHelper.GetService<User>();
        // NEW
        //this.BindingContext = new ShowMyPokemonPageViewModel();

        // faktiskt hämtar pokemon från api med all information
        //var pokeService = new PokeService();
        //var task = Task.Run(() => pokeService.GetUsersPokemons(_user));
        //task.Wait();
        //Pokemons = task.Result.ToList();

        //ListOfPokemons.ItemsSource = Pokemons;
    }

    public static async Task<Pokemon> GetPokemon(string pokemonName)
    {
        var pokeService = new PokeService();
        var pokemon = pokeService.GetOnePokemon(pokemonName);
        //var pokeService = new PokeService(new HttpService()).GetUsersPokemons(user);

        return await pokemon;
    }

    //private async void OnItemSelectedGoToPokemonDetailsPage(object sender, SelectedItemChangedEventArgs e)
    //{
    //    //var pokemon = ((sender as SelectedItemChangedEventArgs).SelectedItem as Pokemon);
    //    //await Navigation.PushAsync(new PokemonDetailsPage());
    //}
}


/*
 

    <!--<ListView ItemsSource="{Binding Pokemons}"
              SeparatorColor="#0C3348"
              VerticalScrollBarVisibility="Default">
        <!--ItemSelected="OnPokemonSelected"--><!--

        <ListView.Header>
            <Image Source="pokemonlogga.png"
                   HorizontalOptions="Center"
                   HeightRequest="150"/>
        </ListView.Header>
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <Grid Padding="10"
                          ColumnDefinitions=".35*, .60*, .5*"
                          RowDefinitions="">

                        <Image Source="{Binding Path=Sprites.Other.Home.FrontDefault}"
                               Grid.Column="0"
                               HorizontalOptions="Center"
                               HeightRequest="150"/>
                                --><!--Source="{Binding ImageSource, Mode=TwoWay}"-->
                               <!--Source="{Binding Path=Sprites.FrontDefault}"--><!--
                        
                        <Label Text="{Binding Path=Name}"
                               Grid.Column="1"
                               FontSize="25"
                               VerticalTextAlignment="Center"/>

                        <Button Text="Show details"
                                Grid.Column="2"
                                Command="{Binding Source={RelativeSource AncestorType={x:Type local:ShowMyPokemonPageViewModel}}, Path=GoToPokemonDetailsPageCommand, Mode=TwoWay}"
                                CommandParameter="{Binding Source={RelativeSource AncestorType={x:Type local:ShowMyPokemonPageViewModel}}, Path=GoToPokemonDetailsPageCommand}"/>

                    </Grid>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>-->
 
 */