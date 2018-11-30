using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Login
{
    public class LoginFacebookMessage : BaseMessage
    {
        public InternalJson Data;

        public LoginFacebookMessage(byte[] data) : base(data)
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
            [JsonProperty("facebook_id")]
            public string FacebookId;
            [JsonProperty("facebook_token")]
            public string FacebookToken;
            [JsonProperty("type")]
            public int Type;
            [JsonProperty("platform")]
            public int Platform;
            [JsonProperty("build_id")]
            public int BuildId;
        }
    }
}
