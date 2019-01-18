using System;
using System.Text;

namespace OSharp.V2.Authorization
{
    public class AuthorizationLinkBuilder
    {
        private readonly int _clientId;
        private const string RequestLink = "https://osu.ppy.sh/oauth/authorize";

        public AuthorizationLinkBuilder(int clientId)
        {
            _clientId = clientId;
        }

        public Uri BuildLink(Uri redirectUri, string tag, AuthorizationScope scope)
        {
            var sb = new StringBuilder($"{RequestLink}?");

            string responseType = "code";

            sb.Append($"response_type={responseType}");
            sb.Append($"&client_id={_clientId}");
            sb.Append($"&redirect_uri={redirectUri.AbsoluteUri}");
            sb.Append($"&state={tag}");
            sb.Append($"&scope={string.Join(" ", scope.GetRequestArray())}");

            return new Uri(sb.ToString());
        }
    }
}
