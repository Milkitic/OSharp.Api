using Newtonsoft.Json;
using System;

namespace OSharp.V2.Client
{
    public class Client
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("redirect")]
        public Uri Redirect { get; set; }

        [JsonProperty("personal_access_client")]
        public bool PersonalAccessClient { get; set; }

        [JsonProperty("password_client")]
        public bool PasswordClient { get; set; }

        [JsonProperty("revoked")]
        public bool Revoked { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
