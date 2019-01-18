using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSharp.V2
{
    [Flags]
    public enum AuthorizationScope
    {
        FriendsRead = 0x1,
        Identify = 0x2,
        All = FriendsRead | Identify
    }

    public static class AuthorizationScopeExtension
    {
        private static readonly IReadOnlyDictionary<AuthorizationScope, string> AuthDictionary =
            new Dictionary<AuthorizationScope, string>
            {
                [AuthorizationScope.FriendsRead] = "friends.read",
                [AuthorizationScope.Identify] = "identify",
            };

        public static string[] GetRequestArray(this AuthorizationScope scopeOption)
        {
            return scopeOption == AuthorizationScope.All
                ? AuthDictionary.Select(k => k.Value).ToArray()
                : GetFlags<AuthorizationScope>(scopeOption).Select(scope => AuthDictionary[scope]).ToArray();
        }

        private static IEnumerable<T> GetFlags<T>(Enum input) where T : Enum
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return (T)value;
        }
    }
}
