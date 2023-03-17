using System.Text.Json.Serialization;

namespace PokedexGo.Models;

public class PokeBall
{
    [JsonPropertyName("attributes")]
    public List<Attribute> Attributes { get; set; }

    [JsonPropertyName("baby_trigger_for")]
    public object BabyTriggerFor { get; set; }

    [JsonPropertyName("category")]
    public Category CategoryCategory { get; set; }

    [JsonPropertyName("cost")]
    public int Cost { get; set; }

    [JsonPropertyName("effect_entries")]
    public List<EffectEntry> EffectEntries { get; set; }

    [JsonPropertyName("flavor_text_entries")]
    public List<FlavorTextEntry> FlavorTextEntries { get; set; }

    [JsonPropertyName("fling_effect")]
    public object FlingEffect { get; set; }

    [JsonPropertyName("fling_power")]
    public object FlingPower { get; set; }

    [JsonPropertyName("game_indices")]
    public List<GameIndex> GameIndices { get; set; }

    [JsonPropertyName("held_by_pokemon")]
    public List<object> HeldByPokemon { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("machines")]
    public List<object> Machines { get; set; }

    [JsonPropertyName("name")]
    public string NameName { get; set; }

    [JsonPropertyName("names")]
    public List<Name> Names { get; set; }

    [JsonPropertyName("sprites")]
    public Sprite Sprites { get; set; }

    public class Attribute
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class EffectEntry
    {
        [JsonPropertyName("effect")]
        public string Effect { get; set; }

        [JsonPropertyName("language")]
        public Language Language { get; set; }

        [JsonPropertyName("short_effect")]
        public string ShortEffect { get; set; }
    }

    public class FlavorTextEntry
    {
        [JsonPropertyName("language")]
        public Language Language { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("version_group")]
        public VersionGroup VersionGroup { get; set; }
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

    public class Language
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("language")]
        public Language Language { get; set; }

        [JsonPropertyName("name")]
        public string NameName { get; set; }
    }

    public class Sprite
    {
        [JsonPropertyName("default")]
        public string Default { get; set; }
    }

    public class VersionGroup
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
