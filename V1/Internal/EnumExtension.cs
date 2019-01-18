﻿using OsuSharp.V1.Beatmap;

namespace OsuSharp.V1.Internal
{
    internal static class EnumExtension
    {
        public static string ToNumericString(this BeatmapGenre genre)
        {
            return ((int)genre).ToString();
        }

        public static string ToNumericString(this BeatmapLanguage language)
        {
            return ((int)language).ToString();
        }
    }
}