using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Login
{
    public class LoginMessage : BaseMessage
    {
        public InternalJson Data;

        private LoginMessage(byte[] data) : base(data)
        {
            try
            {
                var jsonString = BytesToString(data, 1);
                Data = JsonConvert.DeserializeObject<InternalJson>(jsonString);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }

        public class InternalJson
        {
            [JsonProperty("username")]
            public string Username;
            [JsonProperty("password")]
            public string Password;
            [JsonProperty("type")]
            public int Type;
            [JsonProperty("platform")]
            public int Platform;
            [JsonProperty("buildId")]
            public int BuildId;
        }
    }
}
