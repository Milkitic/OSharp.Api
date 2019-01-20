using System;
using OSharp.V1.Internal;

namespace OSharp.V1.Beatmap
{
    /// <summary>
    /// Beatmap extra metadata and methods.
    /// </summary>
    public class BeatmapExtra
    {
        private readonly OsuBeatmap _beatmap;

        /// <summary>
        /// Initialize beatmap extra class with beatmap.
        /// </summary>
        /// <param name="beatmap">Specified osu beatmap.</param>
        public BeatmapExtra(OsuBeatmap beatmap)
        {
            _beatmap = beatmap;
        }

        /// <summary>
        /// Get uri of map thumbnail of the map.
        /// </summary>
        public Uri ThumbnailUri => new Uri($"{Link.BeatmapSetThumbUri}{_beatmap.BeatmapSetId}l.jpg");
        /// <summary>
        /// Get uri of beatmap-set of the map.
        /// </summary>
        public Uri BeatmapSetUri => new Uri($"{Link.BeatmapSetUri}{_beatmap.BeatmapSetId}l.jpg");
        /// <summary>
        /// Get uri of beatmap of the map.
        /// </summary>
        public Uri BeatmapUri => new Uri($"{Link.BeatmapUri}{_beatmap.BeatmapId}l.jpg");
        /// <summary>
        /// Get download uri of the map.
        /// </summary>
        public Uri DownloadUri => new Uri($"{Link.BeatmapDownloadUri}{_beatmap.BeatmapSetId}");
        /// <summary>
        /// Get NO-VIDEO download URI of the map.
        /// </summary>
        public Uri DownloadWithoutVideoUri => new Uri($"{Link.BeatmapDownloadUri}{_beatmap.BeatmapSetId}n");
        /// <summary>
        /// Get osu!direct URI of the map.
        /// </summary>
        public Uri OsuDirectUri => new Uri($"{Link.OsuDirect}{_beatmap.BeatmapSetId}");
    }
}