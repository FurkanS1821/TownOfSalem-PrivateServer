using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Global
{
    public class RegisterAccountMessage : BaseMessage
    {
        public InternalJson Data;

        public RegisterAccountMessage(byte[] data) : base(data, true)
        {
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
            [JsonProperty("steam_auth_ticket")]
            public string SteamAuthTicket;
        }
    }
}