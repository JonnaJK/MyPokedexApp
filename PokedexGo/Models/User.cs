namespace PokedexGo.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Pokemon> Pokemon { get; set; } = new();
    public List<Pokemon> FavoritePokemon { get; set; } = new();
    public List<Pokemon> WantedPokemon { get; set; } = new();
    public List<PokeBall> PokeBalls { get; set; } = new();
}
