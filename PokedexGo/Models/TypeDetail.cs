using System.Text.Json.Serialization;

namespace PokedexGo.Models;

public class TypeDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("damage_relations")]
    public DamageRelations DamageRelations { get; set; }

    [JsonPropertyName("past_damage_relations")]
    public List<PastDamageRelation> PastDamageRelations { get; set; }

    [JsonPropertyName("game_indices")]
    public List<GameIndex> GameIndices { get; set; }

    [JsonPropertyName("generation")]
    public Generation Generation { get; set; }

    [JsonPropertyName("move_damage_class")]
    public MoveDamageClass MoveDamageClass { get; set; }

    [JsonPropertyName("names")]
    public List<Name> Names { get; set; }

    [JsonPropertyName("pokemon")]
    public List<Pokemon> Pokemon { get; set; }

    [JsonPropertyName("moves")]
    public List<Move> Moves { get; set; }
}

public class DamageRelations
{
    [JsonPropertyName("no_damage_to")]
    public List<NoDamageTo> NoDamageTo { get; set; }

    [JsonPropertyName("half_damage_to")]
    public List<HalfDamageTo> HalfDamageTo { get; set; }

    [JsonPropertyName("double_damage_to")]
    public List<DoubleDamageTo> DoubleDamageTo { get; set; }

    [JsonPropertyName("no_damage_from")]
    public List<NoDamageFrom> NoDamageFrom { get; set; }

    [JsonPropertyName("half_damage_from")]
    public List<HalfDamageFrom> HalfDamageFrom { get; set; }

    [JsonPropertyName("double_damage_from")]
    public List<DoubleDamageFrom> DoubleDamageFrom { get; set; }
}

public class DoubleDamageFrom
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class DoubleDamageTo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class GameIndex
{
    [JsonPropertyName("game_index")]
    public int GameIndexGameIndex { get; set; }

    [JsonPropertyName("generation")]
    public Generation Generation { get; set; }
}

public class Generation
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class HalfDamageFrom
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class HalfDamageTo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Language
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Move
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class MoveDamageClass
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Name
{
    [JsonPropertyName("name")]
    public string NameName { get; set; }

    [JsonPropertyName("language")]
    public Language Language { get; set; }
}

public class NoDamageFrom
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class NoDamageTo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class PastDamageRelation
{
    [JsonPropertyName("generation")]
    public Generation Generation { get; set; }

    [JsonPropertyName("damage_relations")]
    public DamageRelations DamageRelations { get; set; }
}