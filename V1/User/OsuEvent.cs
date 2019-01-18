using System;
using CSharpOsu.V1.Internal;
using Newtonsoft.Json;

namespace CSharpOsu.V1.User
{
    public class OsuEvent
    {
        [JsonProperty("display_html")]
        public string DisplayHtml { get; set; }

        [JsonProperty("beatmap_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BeatmapId { get; set; }

        [JsonProperty("beatmapset_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BeatmapSetId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("epicfactor")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long EpicFactor { get; set; }
    }
}