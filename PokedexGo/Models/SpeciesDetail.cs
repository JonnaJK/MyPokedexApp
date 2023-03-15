using System.Text.Json.Serialization;

namespace PokedexGo.Models;

public class SpeciesDetail
{
    [JsonPropertyName("base_happiness")]
    public int BaseHappiness { get; set; }
    [JsonPropertyName("capture_rate")]
    public int CaptureRate { get; set; }
    [JsonPropertyName("color")]
    public Color ColorColor { get; set; }
    [JsonPropertyName("egg_groups")]
    public Egg_Groups[] EggGroups { get; set; }
    [JsonPropertyName("evolution_chain")]
    public Evolution_Chain EvolutionChain { get; set; }
    [JsonPropertyName("evolves_from_species")]
    public object EvolvesFromSpecies { get; set; }
    [JsonPropertyName("flavor_text_entries")]
    public Flavor_Text_Entries[] FlavorTextEntries { get; set; }
    [JsonPropertyName("form_descriptions")]
    public Form_Descriptions[] FormDescriptions { get; set; }
    [JsonPropertyName("forms_switchable")]
    public bool FormsSwitchable { get; set; }
    [JsonPropertyName("gender_rate")]
    public int GenderRate { get; set; }
    [JsonPropertyName("genera")]
    public Genera[] GeneraGenera { get; set; }
    [JsonPropertyName("generation")]
    public Generation GenerationGeneration { get; set; }
    [JsonPropertyName("growth_rate")]
    public Growth_Rate GrowthRate { get; set; }
    [JsonPropertyName("habitat")]
    public Habitat HabitatHabitat { get; set; }
    [JsonPropertyName("has_gender_differences")]
    public bool HasGenderDifferences { get; set; }
    [JsonPropertyName("hatch_counter")]
    public int HatchCounter { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("is_baby")]
    public bool IsBaby { get; set; }
    [JsonPropertyName("is_legendary")]
    public bool IsLegendary { get; set; }
    [JsonPropertyName("is_mythical")]
    public bool IsMythical { get; set; }
    [JsonPropertyName("name")]
    public string NameName { get; set; }
    [JsonPropertyName("names")]
    public Name[] Names { get; set; }
    [JsonPropertyName("order")]
    public int Order { get; set; }
    [JsonPropertyName("pal_park_encounters")]
    public Pal_Park_Encounters[] PalParkEncounters { get; set; }
    [JsonPropertyName("pokedex_numbers")]
    public Pokedex_Numbers[] PokedexNumbers { get; set; }
    [JsonPropertyName("shape")]
    public Shape ShapeShape { get; set; }
    [JsonPropertyName("varieties")]
    public Variety[] Varieties { get; set; }


    public class Color
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Evolution_Chain
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Generation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Growth_Rate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Habitat
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Shape
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Egg_Groups
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Flavor_Text_Entries
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }
        [JsonPropertyName("language")]
        public Language Language { get; set; }
        [JsonPropertyName("version")]
        public Version Version { get; set; }
    }

    public class Language
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Version
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Form_Descriptions
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("language")]
        public Language1 Language { get; set; }
    }

    public class Language1
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Genera
    {
        [JsonPropertyName("genus")]
        public string Genus { get; set; }
        [JsonPropertyName("language")]
        public Language2 Language { get; set; }
    }

    public class Language2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("language")]
        public Language3 Language { get; set; }
        [JsonPropertyName("name")]
        public string NameName { get; set; }
    }

    public class Language3
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Pal_Park_Encounters
    {
        [JsonPropertyName("area")]
        public Area Area { get; set; }
        [JsonPropertyName("base_score")]
        public int BaseScore { get; set; }
        [JsonPropertyName("rate")]
        public int Rate { get; set; }
    }

    public class Area
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Pokedex_Numbers
    {
        [JsonPropertyName("entry_number")]
        public int EntryNumber { get; set; }
        [JsonPropertyName("pokedex")]
        public Pokedex Pokedex { get; set; }
    }

    public class Pokedex
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Variety
    {
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
        [JsonPropertyName("pokemon")]
        public Pokemon Pokemon { get; set; }
    }

    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}
