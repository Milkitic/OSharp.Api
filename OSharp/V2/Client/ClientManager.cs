using Newtonsoft.Json;
using OSharp.HttpClient;
using System;
using System.Collections.Generic;

namespace OSharp.V2.Client
{
    public class ClientManager
    {
        private static readonly HttpClientUtility HttpClient = new HttpClientUtility();

        public string CsrfToken { get; }
        public string OsuSession { get; }

        private const string ClientLink = "https://osu.ppy.sh/oauth/clients";
        //private const string TokenKey = "XSRF-TOKEN";
        private const string TokenKey = "X-CSRF-TOKEN";
        public ClientManager(string csrfToken, string osuSession)
        {
            CsrfToken = csrfToken;
            OsuSession = osuSession;
        }

        public ClientManager(string csrfToken)
        {
            CsrfToken = csrfToken;
        }

        public Client CreateClient(string name, Uri redirectUri)
        {
            string json = HttpClient.HttpPostJson(
                url: ClientLink,
                args: new Dictionary<string, string>
                {
                    ["name"] = name,
                    ["redirect"] = redirectUri.AbsoluteUri
                },
                argsHeader: new Dictionary<string, string>
                {
                    [TokenKey] = CsrfToken,
                    ["Cookie"] = $"osu_session={OsuSession};",
                }
            );
            return JsonConvert.DeserializeObject<Client>(json);
        }

        public void GetClients()
        {
            string json = HttpClient.HttpGet(
                url: ClientLink,
                argsHeader: new Dictionary<string, string>
                {
                    [TokenKey] = CsrfToken,
                }
            );
        }

        public void EditClient(int clientId, string newName, Uri newRedirectUri)
        {
            string json = HttpClient.HttpPutJson(
                url: $"{ClientLink}/{clientId}",
                args: new Dictionary<string, string>
                {
                    ["name"] = newName,
                    ["redirect"] = newRedirectUri.AbsoluteUri
                },
                argsHeader: new Dictionary<string, string>
                {
                    [TokenKey] = CsrfToken,
                }
            );
        }

        public void RevokeClient(int clientId)
        {
            string json = HttpClient.HttpDelete(
                url: $"{ClientLink}/{clientId}",
                argsHeader: new Dictionary<string, string>
                {
                    [TokenKey] = CsrfToken,
                }
            );
        }
    }
}
