﻿using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokedexGo.Models;

public partial class Pokemon
{
    #region JsonProperties

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("abilities")]
    public Ability[] Abilities { get; set; }

    [JsonPropertyName("forms")]
    public Species[] Forms { get; set; }

    [JsonPropertyName("game_indices")]
    public GameIndex[] GameIndices { get; set; }

    [JsonPropertyName("held_items")]
    public HeldItem[] HeldItems { get; set; }

    [JsonPropertyName("location_area_encounters")]
    public string LocationAreaEncounters { get; set; }

    [JsonPropertyName("moves")]
    public Move[] Moves { get; set; }

    [JsonPropertyName("species")]
    public Species Species { get; set; }

    [JsonPropertyName("sprites")]
    public Sprites Sprites { get; set; }

    [JsonPropertyName("stats")]
    public Stat[] Stats { get; set; }

    [JsonPropertyName("types")]
    public TypeElement[] Types { get; set; }

    [JsonPropertyName("past_types")]
    public PastType[] PastTypes { get; set; }


    public partial class Ability
    {
        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("ability")]
        public Species AbilityAbility { get; set; }
    }

    public partial class GameIndex
    {
        [JsonPropertyName("game_index")]
        public int GameIndexGameIndex { get; set; }

        [JsonPropertyName("version")]
        public Species Version { get; set; }
    }

    public partial class HeldItem
    {
        [JsonPropertyName("item")]
        public Species Item { get; set; }

        [JsonPropertyName("version_details")]
        public List<VersionDetail> VersionDetails { get; set; }
    }

    public partial class VersionDetail
    {
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("version")]
        public Species Version { get; set; }
    }

    public partial class Move
    {
        [JsonPropertyName("move")]
        public Species MoveMove { get; set; }

        [JsonPropertyName("version_group_details")]
        public List<VersionGroupDetail> VersionGroupDetails { get; set; }
    }

    public partial class VersionGroupDetail
    {
        [JsonPropertyName("level_learned_at")]
        public int LevelLearnedAt { get; set; }

        [JsonPropertyName("version_group")]
        public Species VersionGroup { get; set; }

        [JsonPropertyName("move_learn_method")]
        public Species MoveLearnMethod { get; set; }
    }

    public partial class PastType
    {
        [JsonPropertyName("generation")]
        public Species Generation { get; set; }

        [JsonPropertyName("types")]
        public List<TypeElement> Types { get; set; }
    }

    public partial class TypeElement
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("type")]
        public Species Type { get; set; }
    }

    public partial class GenerationV
    {
        [JsonPropertyName("black-white")]
        public Sprites BlackWhite { get; set; }
    }

    public partial class GenerationIv
    {
        [JsonPropertyName("diamond-pearl")]
        public Sprites DiamondPearl { get; set; }

        [JsonPropertyName("heartgold-soulsilver")]
        public Sprites HeartgoldSoulsilver { get; set; }

        [JsonPropertyName("platinum")]
        public Sprites Platinum { get; set; }
    }

    public partial class Versions
    {
        [JsonPropertyName("generation-i")]
        public GenerationI GenerationI { get; set; }

        [JsonPropertyName("generation-ii")]
        public GenerationIi GenerationIi { get; set; }

        [JsonPropertyName("generation-iii")]
        public GenerationIii GenerationIii { get; set; }

        [JsonPropertyName("generation-iv")]
        public GenerationIv GenerationIv { get; set; }

        [JsonPropertyName("generation-v")]
        public GenerationV GenerationV { get; set; }

        [JsonPropertyName("generation-vi")]
        public Dictionary<string, Home> GenerationVi { get; set; }

        [JsonPropertyName("generation-vii")]
        public GenerationVii GenerationVii { get; set; }

        [JsonPropertyName("generation-viii")]
        public GenerationViii GenerationViii { get; set; }
    }

    public partial class GenerationI
    {
        [JsonPropertyName("red-blue")]
        public RedBlue RedBlue { get; set; }

        [JsonPropertyName("yellow")]
        public RedBlue Yellow { get; set; }
    }

    public partial class RedBlue
    {
        [JsonPropertyName("back_default")]
        public Uri BackDefault { get; set; }

        [JsonPropertyName("back_gray")]
        public Uri BackGray { get; set; }

        [JsonPropertyName("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonPropertyName("front_gray")]
        public Uri FrontGray { get; set; }
    }

    public partial class GenerationIi
    {
        [JsonPropertyName("crystal")]
        public Crystal Crystal { get; set; }

        [JsonPropertyName("gold")]
        public Crystal Gold { get; set; }

        [JsonPropertyName("silver")]
        public Crystal Silver { get; set; }
    }

    public partial class Crystal
    {
        [JsonPropertyName("back_default")]
        public Uri BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public Uri BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public Uri FrontShiny { get; set; }
    }

    public partial class GenerationIii
    {
        [JsonPropertyName("emerald")]
        public Emerald Emerald { get; set; }

        [JsonPropertyName("firered-leafgreen")]
        public Crystal FireredLeafgreen { get; set; }

        [JsonPropertyName("ruby-sapphire")]
        public Crystal RubySapphire { get; set; }
    }

    public partial class Emerald
    {
        [JsonPropertyName("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public Uri FrontShiny { get; set; }
    }

    public partial class Home
    {
        [JsonPropertyName("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public Uri FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public partial class GenerationVii
    {
        [JsonPropertyName("icons")]
        public DreamWorld Icons { get; set; }

        [JsonPropertyName("ultra-sun-ultra-moon")]
        public Home UltraSunUltraMoon { get; set; }
    }

    public partial class DreamWorld
    {
        [JsonPropertyName("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }
    }

    public partial class GenerationViii
    {
        [JsonPropertyName("icons")]
        public DreamWorld Icons { get; set; }
    }

    public partial class Other
    {
        [JsonPropertyName("dream_world")]
        public DreamWorld DreamWorld { get; set; }

        [JsonPropertyName("home")]
        public Home Home { get; set; }

        [JsonPropertyName("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public partial class OfficialArtwork
    {
        [JsonPropertyName("front_default")]
        public Uri FrontDefault { get; set; }
    }

    public partial class Stat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("effort")]
        public int Effort { get; set; }

        [JsonPropertyName("stat")]
        public Species StatStat { get; set; }
    }
    #endregion

    #region OwnProperties
    public string FlavorText { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsWanted { get; set; }
    #endregion

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
        {
            new DateOnlyConverter(),
            new TimeOnlyConverter(),
            IsoDateTimeOffsetConverter.Singleton
        },
        };
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;
        public DateOnlyConverter() : this(null) { }

        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null) { }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string? _dateTimeFormat;
        private CultureInfo? _culture;

        public DateTimeStyles DateTimeStyles
        {
            get => _dateTimeStyles;
            set => _dateTimeStyles = value;
        }

        public string? DateTimeFormat
        {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
        }

        public CultureInfo Culture
        {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            string text;


            if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
            {
                value = value.ToUniversalTime();
            }

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                }
            }
            else
            {
                return default(DateTimeOffset);
            }
        }


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
    }
}
