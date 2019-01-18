using System;
using Newtonsoft.Json;
using OSharp.V1.Internal;

namespace OSharp.V1.Score
{
    public class OsuPlayScore : IScore
    {
        [JsonProperty("score_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ScoreId { get; set; }

        [JsonProperty("score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Score { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("count300")]
        public int Count300 { get; set; }

        [JsonProperty("count100")]
        public int Count100 { get; set; }

        [JsonProperty("count50")]
        public int Count50 { get; set; }

        [JsonProperty("countmiss")]
        public int CountMiss { get; set; }

        [JsonProperty("maxcombo")]
        public int MaxCombo { get; set; }

        [JsonProperty("countkatu")]
        public int CountKatu { get; set; }

        [JsonProperty("countgeki")]
        public int CountGeki { get; set; }

        [JsonIgnore]
        public bool IsPerfect => PerfectInt == 1;
        [JsonProperty("perfect")]
        internal int PerfectInt { get; set; }

        [JsonProperty("enabled_mods")]
        public Mod EnabledMods { get; set; }

        [JsonProperty("user_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UserId { get; set; }

        [JsonIgnore]
        public DateTimeOffset Date => DateTimeOffset.Parse(DateString);
        [JsonProperty("date")]
        public string DateString { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("pp")]
        public float Pp { get; set; }

        [JsonIgnore]
        public bool ReplayAvailable => ReplayAvailableInt == 1;
        [JsonProperty("replay_available")]
        private int ReplayAvailableInt { get; set; }
    }
}
