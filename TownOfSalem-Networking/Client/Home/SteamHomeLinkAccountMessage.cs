using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Home
{
    public class SteamHomeLinkAccountMessage : BaseMessage
    {
        public InternalJson Data;

        public SteamHomeLinkAccountMessage(byte[] data) : base(data)
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
            [JsonProperty("steam_auth_ticket")]
            public string SteamAuthTicket;
        }
    }
}