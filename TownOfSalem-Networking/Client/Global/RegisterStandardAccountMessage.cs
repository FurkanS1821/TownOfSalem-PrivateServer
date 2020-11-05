using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Global
{
    public class RegisterStandardAccountMessage : BaseMessage
    {
        public InternalJson Data;

        public RegisterStandardAccountMessage(byte[] data) : base(data)
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
            [JsonProperty("username")]
            public string Username;
            [JsonProperty("password")]
            public string Password;
            [JsonProperty("email")]
            public string Email;
            [JsonProperty("referer")]
            public string Referer;
        }
    }
}