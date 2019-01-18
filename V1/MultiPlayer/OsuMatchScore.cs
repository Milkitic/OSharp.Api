using CSharpOsu.V1.Internal;
using CSharpOsu.V1.Score;
using Newtonsoft.Json;

namespace CSharpOsu.V1.MultiPlayer
{
    public class OsuMatchScore : IScore
    {
        /// <summary>
        /// Index of player's slot (from 0).
        /// </summary>
        [JsonProperty("slot")]
        public int Slot { get; set; }

        /// <summary>
        /// 0 = No team, 1 = Blue, 2 = Red.
        /// </summary>
        [JsonProperty("team")]
        public int Team { get; set; }

        [JsonProperty("user_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UserId { get; set; }

        [JsonProperty("score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Score { get; set; }

        [JsonProperty("maxcombo")]
        public int MaxCombo { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("count50")]
        public int Count50 { get; set; }

        [JsonProperty("count100")]
        public int Count100 { get; set; }

        [JsonProperty("count300")]
        public int Count300 { get; set; }

        [JsonProperty("countmiss")]
        public int CountMiss { get; set; }

        [JsonProperty("countgeki")]
        public int CountGeki { get; set; }

        [JsonProperty("countkatu")]
        public int CountKatu { get; set; }

        [JsonIgnore]
        public bool IsPerfect => PerfectInt == 1;
        [JsonProperty("perfect")]
        private int PerfectInt { get; set; }

        [JsonIgnore]
        public bool Pass => PassInt == 1;
        [JsonProperty("pass")]
        private int PassInt { get; set; }
    }
}
