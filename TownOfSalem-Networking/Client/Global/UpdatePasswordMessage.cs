using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Global
{
    public class UpdatePasswordMessage : BaseMessage
    {
        public InternalJson Data;

        public UpdatePasswordMessage(byte[] data) : base(data, true)
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
            [JsonProperty("old_password")]
            public string OldPassword;
            [JsonProperty("new_password")]
            public string NewPassword;
        }
    }
}