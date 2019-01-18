using Newtonsoft.Json;

namespace OsuSharp.V1.Replay
{
    public class OsuReplay
    {
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonIgnore]
        public bool IsValid => Content != null && Encoding != null;
    }
}
