namespace PokedexGo.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Pokemon> FavoritePokemons { get; set; }
    public List<Pokemon> WantedPokemons { get; set; }
}
