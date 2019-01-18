using System;
using CSharpOsu.V1.Internal;
using Newtonsoft.Json;

namespace CSharpOsu.V1.User
{

    public class OsuUser
    {
        [JsonProperty("user_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UserId { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("join_date")]
        public DateTimeOffset JoinDate { get; set; }

        [JsonProperty("count300")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Count300 { get; set; }

        [JsonProperty("count100")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Count100 { get; set; }

        [JsonProperty("count50")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Count50 { get; set; }

        [JsonProperty("playcount")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PlayCount { get; set; }

        [JsonProperty("ranked_score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long RankedScore { get; set; }

        [JsonProperty("total_score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TotalScore { get; set; }

        [JsonProperty("pp_rank")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PpRank { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("pp_raw")]
        public float? PpRaw { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("count_rank_ss")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountRankSs { get; set; }

        [JsonProperty("count_rank_ssh")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountRankSsh { get; set; }

        [JsonProperty("count_rank_s")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountRankS { get; set; }

        [JsonProperty("count_rank_sh")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountRankSh { get; set; }

        [JsonProperty("count_rank_a")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountRankA { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("total_seconds_played")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TotalSecondsPlayed { get; set; }

        [JsonProperty("pp_country_rank")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PpCountryRank { get; set; }

        [JsonProperty("events")]
        public OsuEvent[] Events { get; set; }
    }
}
