using System.IO;
using Newtonsoft.Json.Linq;

namespace TownOfSalem_Networking.Client.Login
{
    public class LoginFacebookMessage : BaseMessage
    {
        private InternalJson _data;

        public LoginFacebookMessage(string facebookId, string facebookToken, LoginType type, Platform platformId,
            int buildId) : base(MessageType.Login)
        {
            _isEncrypted = true;
            _data = new InternalJson
            {
                FacebookId = facebookId,
                FacebookToken = facebookToken,
                Type = (int)type,
                Platform = (int)platformId,
                BuildId = buildId
            };
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(_data.ToJson().ToCharArray());
        }

        private class InternalJson
        {
            public string FacebookId;
            public string FacebookToken;
            public int Type;
            public int Platform;
            public int BuildId;

            public string ToJson()
            {
                var json = new JObject
                {
                    {"facebook_id", FacebookId},
                    {"facebook_token", FacebookToken},
                    {"type", Type},
                    {"platform", Platform},
                    {"build_id", BuildId}
                };

                return json.ToString();
            }
        }
    }
}
