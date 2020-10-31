using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Login
{
    public class LoginSteamWithIDAndAuthTicket : BaseMessage
    {
        public InternalJson Data;

        public LoginSteamWithIDAndAuthTicket(byte[] data) : base(data)
        {
            try
            {
                var jsonString = BytesToString(data, 1);
                Data = JsonConvert.DeserializeObject<InternalJson>(jsonString);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }

        [JsonObject]
        public class InternalJson
        {
            [JsonProperty("steam_id")]
            public string SteamId;
            [JsonProperty("type")]
            public int Type;
            [JsonProperty("platform")]
            public int Platform;
            [JsonProperty("build_id")]
            public int BuildId;
            [JsonProperty("steam_auth_ticket")]
            public string SteamAuthTicket;
        }
    }
}