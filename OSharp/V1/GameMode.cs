using Newtonsoft.Json;

namespace OSharp.V1
{
    public enum GameMode
    {
        [JsonProperty("osu")]
        Standard = 0,
        [JsonProperty("taiko")]
        Taiko,
        [JsonProperty("fruits")]
        CtB,
        [JsonProperty("mania")]
        OsuMania
    };
}