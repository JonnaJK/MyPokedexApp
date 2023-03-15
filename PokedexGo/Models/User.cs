namespace PokedexGo.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public List<Pokemon> Pokemon { get; set; } = new();
    public List<Pokemon> FavoritePokemon { get; set; } = new();
    public List<Pokemon> WantedPokemon { get; set; } = new();
}
