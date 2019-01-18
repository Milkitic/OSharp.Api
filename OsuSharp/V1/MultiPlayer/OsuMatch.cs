using Newtonsoft.Json;

namespace OsuSharp.V1.MultiPlayer
{
    public class OsuMatch
    {
        [JsonProperty("match")]
        public OsuMatchMetadata Match { get; set; }

        [JsonProperty("games")]
        public OsuMatchGame[] Games { get; set; }
    }
}