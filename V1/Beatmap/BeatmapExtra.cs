using System;
using CSharpOsu.V1.Internal;

namespace CSharpOsu.V1.Beatmap
{
    public class BeatmapExtra
    {
        private readonly OsuBeatmap _beatmap;
      
        public BeatmapExtra(OsuBeatmap beatmap)
        {
            _beatmap = beatmap;
        }

        public Uri ThumbnailUri => new Uri($"{Link.BeatmapSetThumbUri}{_beatmap.BeatmapSetId}l.jpg");
        public Uri BeatmapSetUri => new Uri($"{Link.BeatmapSetUri}{_beatmap.BeatmapSetId}l.jpg");
        public Uri BeatmapUri => new Uri($"{Link.BeatmapUri}{_beatmap.BeatmapId}l.jpg");

        public Uri DownloadUri => new Uri($"{Link.BeatmapDownloadUri}{_beatmap.BeatmapSetId}");
        public Uri DownloadWithoutVideoUri => new Uri($"{Link.BeatmapDownloadUri}{_beatmap.BeatmapSetId}n");
        public Uri OsuDirectUri => new Uri($"{Link.OsuDirect}{_beatmap.BeatmapSetId}");
    }
}