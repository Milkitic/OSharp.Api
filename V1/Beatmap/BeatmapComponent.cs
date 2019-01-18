namespace CSharpOsu.V1.Beatmap
{
    public class BeatmapId : BeatmapComponent
    {
        public BeatmapId(long mapId) : base(mapId, Type.Beatmap)
        {
        }
        public BeatmapId(string mapId) : base(long.Parse(mapId), Type.Beatmap)
        {
        }
    }

    public class BeatmapSetId : BeatmapComponent
    {
        public BeatmapSetId(long setId) : base(setId, Type.BeatmapSet)
        {
        }
        public BeatmapSetId(string setId) : base(long.Parse(setId), Type.BeatmapSet)
        {
        }
    }

    public abstract class BeatmapComponent
    {
        protected BeatmapComponent(long id, Type idType)
        {
            Id = id;
            IdType = idType;
        }

        public long Id { get; }
        public Type IdType { get; }

        public static BeatmapId FromMapId(long id) => new BeatmapId(id);
        public static BeatmapId FromMapId(string id) => new BeatmapId(id);

        public static BeatmapSetId FromSetId(long id) => new BeatmapSetId(id);

        public static BeatmapSetId FromSetId(string id) => new BeatmapSetId(id);

        public enum Type
        {
            Beatmap, BeatmapSet
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
