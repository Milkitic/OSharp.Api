using System;
using Newtonsoft.Json;
using OSharp.V1.Internal;

namespace OSharp.V1.Score
{
    public class OsuUserBest : IScore
    {
        [JsonProperty("beatmap_id")]
        public int BeatmapId { get; set; }

        /// <inheritdoc />
        [JsonProperty("score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Score { get; set; }

        /// <inheritdoc />
        [JsonProperty("maxcombo")]
        public int MaxCombo { get; set; }

        /// <inheritdoc />
        [JsonProperty("count300")]
        public int Count300 { get; set; }

        /// <inheritdoc />
        [JsonProperty("count100")]
        public int Count100 { get; set; }

        /// <inheritdoc />
        [JsonProperty("count50")]
        public int Count50 { get; set; }

        /// <inheritdoc />
        [JsonProperty("countmiss")]
        public int CountMiss { get; set; }

        /// <inheritdoc />
        [JsonProperty("countkatu")]
        public int CountKatu { get; set; }

        /// <inheritdoc />
        [JsonProperty("countgeki")]
        public int CountGeki { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public bool IsPerfect => PerfectInt == 1;
        [JsonProperty("perfect")]
        private int PerfectInt { get; set; }

        [JsonProperty("enabled_mods")]
        public Mod EnabledMods { get; set; }

        /// <inheritdoc />
        [JsonProperty("user_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UserId { get; set; }

        [JsonIgnore]
        public DateTimeOffset Date => DateTimeOffset.Parse(DateString);
        [JsonProperty("date")]
        public string DateString { get; set; }

        /// <inheritdoc />
        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("pp")]
        public float Pp { get; set; }
    }
}
