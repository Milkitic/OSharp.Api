namespace OSharp.V1.Beatmap
{
    public class ConvertibleGameMode
    {
        public GameMode GameMode { get; }
        public BeatmapConvertOption ConvertOption { get; }

        public ConvertibleGameMode(GameMode gameMode, bool convert = false)
        {
            GameMode = gameMode;
            ConvertOption = convert ? BeatmapConvertOption.Included : BeatmapConvertOption.NotIncluded;
        }

        public static ConvertibleGameMode WithoutConvert(GameMode gameMode) => new ConvertibleGameMode(gameMode);
        public static ConvertibleGameMode WithConvert(GameMode gameMode) => new ConvertibleGameMode(gameMode, true);
    }
}
