using System;
using Newtonsoft.Json;
using OSharp.V1.Internal;

namespace OSharp.V1.MultiPlayer
{
    public class OsuMatchGame
    {
        [JsonProperty("game_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GameId { get; set; }

        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTimeOffset? EndTime { get; set; }

        [JsonProperty("beatmap_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BeatmapId { get; set; }

        [JsonProperty("play_mode")]
        public GameMode PlayMode { get; set; }

        /// <summary>
        /// Couldn't find.
        /// </summary>
        [JsonProperty("match_type")]
        public string MatchType { get; set; }

        [JsonProperty("scoring_type")]
        public MatchScoringType ScoringType { get; set; }

        [JsonProperty("team_type")]
        public MatchTeamType TeamType { get; set; }

        [JsonProperty("mods")]
        public Mod Mods { get; set; }

        [JsonProperty("scores")]
        public OsuMatchScore[] Scores { get; set; }
    }
}