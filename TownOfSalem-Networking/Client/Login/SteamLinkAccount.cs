using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Login
{
    public class SteamLinkAccount : BaseMessage
    {
        public InternalJson Data;

        public SteamLinkAccount(byte[] data) : base(data)
        {
            var jsonString = BytesToString(data, 1);
            Data = JsonConvert.DeserializeObject<InternalJson>(jsonString);
        }

        [JsonObject]
        public class InternalJson
        {
            [JsonProperty("username")]
            public string Username;
            [JsonProperty("password")]
            public string Password;
            [JsonProperty("steam_auth_ticket")]
            public string SteamAuthTicket;
        }
    }
}