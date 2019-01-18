using System;
using System.IO;
using OsuSharp.V1.Beatmap;
using OsuSharp.V1.Internal;
using OsuSharp.V1.Score;

namespace OsuSharp.V1.Replay
{
    public class ReplayExtra
    {
        private readonly OsuReplay _replay;
        private readonly OsuPlayScore _score;
        private readonly OsuBeatmap _beatmap;
        private byte[] _data;

        public ReplayExtra(OsuReplay replay, OsuPlayScore score, OsuBeatmap beatmap)
        {
            if (!replay.IsValid)
                throw new NullReferenceException("The specified replay doesn't exist.");

            _replay = replay;
            _score = score;
            _beatmap = beatmap;
        }

        public byte[] GetRawData(bool useCache = true)
        {
            if (useCache && _data != null)
                return _data;

            var replayHashData = OsrBinaryUtility.ComputeMd5Hash(_score.MaxCombo + "osu" + _score.UserName + _beatmap.FileMd5 + _score.Score + _score.Rank);
            var content = Convert.FromBase64String(_replay.Content);
            var mode = ((int)_beatmap.GameMode).ToString();

            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter binWriter = new BinaryWriter(ms))
            using (BinaryReader binReader = new BinaryReader(binWriter.BaseStream))
            {
                // Begin
                binWriter.WriteByte(mode);                                         // Write osu mode.
                binWriter.WriteInteger(0.ToString());                              // Write osu version. (Unknown)
                binWriter.WriteString(_beatmap.FileMd5);                           // Write beatmap MD5.
                binWriter.WriteString(_score.UserName);                            // Write username.
                binWriter.WriteString(replayHashData);                             // Write replay MD5.
                binWriter.WriteShort(_score.Count300.ToString());                  // Write 300s count.
                binWriter.WriteShort(_score.Count100.ToString());                  // Write 100s count.
                binWriter.WriteShort(_score.Count50.ToString());                   // Write 50s count.
                binWriter.WriteShort(_score.CountGeki.ToString());                 // Write geki count.
                binWriter.WriteShort(_score.CountKatu.ToString());                 // Write katu count.
                binWriter.WriteShort(_score.CountMiss.ToString());                 // Write miss count.
                binWriter.WriteInteger(_score.Score.ToString());                   // Write score.
                binWriter.WriteShort(_score.MaxCombo.ToString());                  // Write max combo.
                binWriter.WriteByte(_score.PerfectInt.ToString());                    // Write if the score is perfect or not.
                binWriter.WriteInteger(((int)_score.EnabledMods).ToString());             // Write which mods where enabled.
                binWriter.WriteString("");                                         // Write life bar hp. (Unknown)
                binWriter.WriteDate(_score.DateString);                            // Write replay timestamp.
                binWriter.WriteInteger(content.Length.ToString());                 // Write replay content length.

                // Content
                binWriter.Write(content);                                          // Write replay content.

                // Final
                binWriter.Write(_score.ScoreId);                                   // Write score id.
                binWriter.Write(BitConverter.GetBytes(Convert.ToUInt32(0)), 4, 0); // Write null byte.

                binReader.BaseStream.Position = 0;
                int streamLength = (int)binReader.BaseStream.Length;

                // [WARNING!]
                // The Get Replay Data from osu!api doesn't have a parameter to retrieve a certain replay.
                // It is possible that the movement of the cursor to be wrong because of that.
                // There is no way to fix it until such parameter is added.

                _data = binReader.ReadBytes(streamLength);
            }

            return _data;
        }

        public void SaveOsrFile(string path, bool useCache = true)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(GetRawData(useCache));
            }
        }
    }
}
