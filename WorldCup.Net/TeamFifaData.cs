namespace WorldCup.Net
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TeamFifaData
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code", NullValueHandling = NullValueHandling.Ignore)]
        public string FifaCode { get; set; }

        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupId { get; set; }

        [JsonProperty("group_letter", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupLetter { get; set; }

        [JsonProperty("wins", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wins { get; set; }

        [JsonProperty("draws", NullValueHandling = NullValueHandling.Ignore)]
        public long? Draws { get; set; }

        [JsonProperty("losses", NullValueHandling = NullValueHandling.Ignore)]
        public long? Losses { get; set; }

        [JsonProperty("games_played", NullValueHandling = NullValueHandling.Ignore)]
        public long? GamesPlayed { get; set; }

        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public long? Points { get; set; }

        [JsonProperty("goals_for", NullValueHandling = NullValueHandling.Ignore)]
        public long? GoalsFor { get; set; }

        [JsonProperty("goals_against", NullValueHandling = NullValueHandling.Ignore)]
        public long? GoalsAgainst { get; set; }

        [JsonProperty("goal_differential", NullValueHandling = NullValueHandling.Ignore)]
        public long? GoalDifferential { get; set; }
    }

    public partial class TeamFifaData
    {
        public static List<TeamFifaData> FromJson(string json) => JsonConvert.DeserializeObject<List<TeamFifaData>>(json, WorldCup.Net.TeamFifaDataConverter.Settings);
    }

    public static class TeamFifaDataSerialize
    {
        public static string ToJson(this List<TeamFifaData> self) => JsonConvert.SerializeObject(self, WorldCup.Net.TeamFifaDataConverter.Settings);
    }

    internal static class TeamFifaDataConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
