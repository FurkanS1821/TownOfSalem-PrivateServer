using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Login
{
    public class SteamLinkAccount : BaseMessage
    {
        public InternalJson Data;

        public SteamLinkAccount(byte[] data) : base(data, true)
        {
            IsEncrypted = true;
            try
            {
                var jsonString = BytesToString(RawData, 1);
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
            [JsonProperty("username")]
            public string Username;
            [JsonProperty("password")]
            public string Password;
            [JsonProperty("steam_auth_ticket")]
            public string SteamAuthTicket;
        }
    }
}