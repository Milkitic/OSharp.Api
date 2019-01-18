using System;
using System.Linq;
using OSharp.V1;
using OSharp.V1.Beatmap;
using OSharp.V1.MultiPlayer;
using OSharp.V1.Replay;
using OSharp.V1.Score;
using OSharp.V1.User;

namespace OSharpTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // api key
            OsuClient client = new OsuClient("YOUR OSU API KEY");


            // user data
            OsuUser user = client.GetUsers(
                nameOrId: UserComponent.FromUserId(2) //or: new UserId(2)
            ).FirstOrDefault();

            OsuUser user2 = client.GetUsers(
                nameOrId: UserComponent.FromUserName("peppy"), //or: new UserName("peppy")
                gameMode: GameMode.Taiko
            ).FirstOrDefault();


            // beatmap data
            OsuBeatmap[] beatmaps = client.GetBeatmaps(
                beatmapSetId: new BeatmapSetId(3720)
            );

            OsuBeatmap beatmap = client.GetBeatmap(
                beatmapId: new BeatmapId("22423") // string is ok
            );

            OsuBeatmapSet beatmapSet = client.GetBeatmapSet(
                beatmapId: new BeatmapId(22423)
            );


            // score data
            OsuPlayScore score = client.GetScores(
                beatmapId: new BeatmapId(22423),
                nameOrId: UserComponent.FromUserId(2)
            ).OrderByDescending(k => k.Score).FirstOrDefault();

            OsuUserBest[] bestScores = client.GetUserBestScores(
                nameOrId: UserComponent.FromUserId(2)
            );

            OsuUserRecent[] recentScores = client.GetUserRecentScores(
                nameOrId: UserComponent.FromUserId(2)
            );


            // score extension method
            double acc1 = score.GetAccuracy(beatmap);
            double acc2 = bestScores.FirstOrDefault().GetAccuracy(beatmap);
            double acc3 = recentScores.FirstOrDefault().GetAccuracy(beatmap);


            // match data
            OsuMatch match = client.GetMatch(12345);


            // replay data (raw movements and clicks base64 string)
            OsuReplay replay = client.GetReplay(
                gameMode: GameMode.Standard,
                nameOrId: UserComponent.FromUserId(2),
                beatmapId: BeatmapComponent.FromMapId(22423) //or: new BeatmapId(22423)
            );


            // These classes will generate metadata like links or other information, and provide extensional methods.
            UserExtra userExtra = new UserExtra(user);
            Uri flagUri = userExtra.FlagUri;
            Uri ppPlusUri = userExtra.PpPlusUri;
            // ...

            BeatmapExtra beatmapExtra = new BeatmapExtra(beatmap);
            Uri setUri = beatmapExtra.BeatmapSetUri;
            Uri directUri = beatmapExtra.OsuDirectUri;
            Uri thumbnailUri = beatmapExtra.ThumbnailUri;
            // ...

            ReplayExtra replayExtra = new ReplayExtra(replay, score, beatmap); // Use this class to transform raw data from api to osr file.
            byte[] data = replayExtra.GetRawData();
            replayExtra.SaveOsrFile("D:\\replay.osr");
        }
    }
}
