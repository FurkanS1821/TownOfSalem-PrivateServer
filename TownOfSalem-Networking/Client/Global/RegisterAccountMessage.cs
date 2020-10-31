using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Global
{
    public class RegisterAccountMessage : BaseMessage
    {
        public InternalJson Data;

        public RegisterAccountMessage(byte[] data) : base(data)
        {
            var jsonString = BytesToString(data, 1);
            Data = JsonConvert.DeserializeObject<InternalJson>(jsonString);
        }

        [JsonObject]
        public class InternalJson
        {
            [JsonProperty("username")]
            public string UserName;
            [JsonProperty("password")]
            public string Password;
            [JsonProperty("email")]
            public string Email;
            [JsonProperty("referer")]
            public string Referer;
            [JsonProperty("facebook_id")]
            public string FacebookId;
            [JsonProperty("facebook_token")]
            public string FacebookToken;
            [JsonProperty("steam_id")]
            public string SteamId;
            [JsonProperty("unique_device_id")]
            public string UniqueDeviceId;
        }
    }
}
