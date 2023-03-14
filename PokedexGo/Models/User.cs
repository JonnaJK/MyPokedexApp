namespace PokedexGo.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public List<Pokemon> Pokemons { get; set; } = new();
    public List<Pokemon> FavoritePokemons { get; set; } = new();
    public List<Pokemon> WantedPokemons { get; set; } = new();
}
