using System;
using Newtonsoft.Json;
using OsuSharp.V1.Internal;

namespace OsuSharp.V1.Beatmap
{
    public class OsuBeatmap
    {
        [JsonProperty("approved")]
        public BeatmapApprovedState? Approved { get; set; }

        [JsonProperty("approved_date")]
        public DateTimeOffset? ApprovedDate { get; set; }

        [JsonProperty("last_update")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("beatmap_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BeatmapId { get; set; }

        [JsonProperty("beatmapset_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BeatmapSetId { get; set; }

        [JsonProperty("bpm")]
        public double Bpm { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("creator_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CreatorId { get; set; }

        [JsonProperty("difficultyrating")]
        public double? DifficultyRating { get; set; }

        [JsonProperty("diff_size")]
        public float? CircleSize { get; set; }

        [JsonProperty("diff_overall")]
        public float? OverallDifficulty { get; set; }

        [JsonProperty("diff_approach")]
        public float? ApproachRate { get; set; }

        [JsonProperty("diff_drain")]
        public float? HealthDrain { get; set; }

        /// <summary>
        /// Seconds from first note to last note not including breaks.
        /// </summary>
        [JsonProperty("hit_length")]
        public int? HitLength { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("genre_id")]
        public BeatmapGenre Genre { get; set; }

        [JsonProperty("language_id")]
        public BeatmapLanguage Language { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Seconds from first note to last note including breaks.
        /// </summary>
        [JsonProperty("total_length")]
        public int? TotalLength { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("file_md5")]
        public string FileMd5 { get; set; }

        [JsonProperty("mode")]
        public GameMode GameMode { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("favourite_count")]
        public int? FavouriteCount { get; set; }

        [JsonProperty("playcount")]
        public int? PlayCount { get; set; }

        [JsonProperty("passcount")]
        public int? PassCount { get; set; }

        [JsonProperty("max_combo")]
        public int? MaxCombo { get; set; }
    }
}
