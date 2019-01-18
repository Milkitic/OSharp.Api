using System;
using System.Collections.Generic;
using System.Linq;

namespace OsuSharp.V1.Beatmap
{
    public class OsuBeatmapSet
    {
        public OsuBeatmapSet(IReadOnlyList<OsuBeatmap> beatmaps)
        {
            Beatmaps = beatmaps;
            //SubmitDate = Beatmaps.First().SubmitDate;
            RankedDate = Beatmaps.Any(k => k.ApprovedDate != null && k.Approved == BeatmapApprovedState.Ranked)
                ? Beatmaps.First().ApprovedDate
                : null;
            QualifiedDate = Beatmaps.Any(k => k.ApprovedDate != null && k.Approved == BeatmapApprovedState.Qualified)
                ? Beatmaps.First().ApprovedDate
                : null;
            ApprovedDate = Beatmaps.Any(k => k.ApprovedDate != null && k.Approved == BeatmapApprovedState.Approved)
                ? Beatmaps.First().ApprovedDate
                : null;
            LovedDate = Beatmaps.Any(k => k.ApprovedDate != null && k.Approved == BeatmapApprovedState.Loved)
                ? Beatmaps.First().ApprovedDate
                : null;
            Status = Beatmaps.First().Approved;
            FavouriteCount = Beatmaps.First().FavouriteCount;
            Id = Beatmaps.First().BeatmapSetId;
            Artist = Beatmaps.First().Artist;
            Title = Beatmaps.First().Title;
            CreatorId = Beatmaps.First().CreatorId;
            Creator = Beatmaps.First().Creator;
        }

        public string Title { get; }

        public string Artist { get; }

        public BeatmapApprovedState? Status { get; }

        public int? FavouriteCount { get; }

        public DateTimeOffset? RankedDate { get; }
        public DateTimeOffset? QualifiedDate { get; }
        public DateTimeOffset? ApprovedDate { get; }
        public DateTimeOffset? LovedDate { get; }
        public DateTimeOffset? SubmitDate => throw new NotImplementedException();

        public long Id { get; }
        public long? CreatorId { get; }
        public string Creator { get; }
        public IReadOnlyList<OsuBeatmap> Beatmaps { get; }
    }
}
