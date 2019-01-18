using System;
using CSharpOsu.V1.Internal;

namespace CSharpOsu.V1.User
{
    public class UserExtra
    {
        private readonly OsuUser _user;

        public UserExtra(OsuUser user)
        {
            _user = user;
        }

        public Uri UserPageUri => new Uri($"{Link.UserPageUri}{_user.UserId}");
        public Uri AvatarUri => new Uri($"{Link.AvatarUri}{_user.UserId}");
        public Uri FlagUri => new Uri($"{Link.FlagUri}{_user.Country.ToLower()}.gif");
        public Uri OsuStatsUri => new Uri($"{Link.OsuStatsUri}{_user.UserName}");
        public Uri OsuTrackUri => new Uri($"{Link.OsuTrackUri}{_user.UserName}n");
        public Uri OsuSkillsUri => new Uri($"{Link.OsuSkillsUri}{_user.UserName}");
        public Uri OsuChanUri => new Uri($"{Link.OsuChanUri}{_user.UserId}");
        public Uri PpPlusUri => new Uri($"{Link.PpPlusUri}{_user.UserId}");
    }
}