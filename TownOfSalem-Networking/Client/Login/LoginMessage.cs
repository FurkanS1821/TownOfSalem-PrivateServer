using System.IO;
using Newtonsoft.Json.Linq;

namespace TownOfSalem_Networking.Client.Login
{
    public class LoginMessage : BaseMessage
    {
        private InternalJson _data;

        private LoginMessage(string username, string password, LoginType type, Platform platformId, int buildId)
            : base(MessageType.Login)
        {
            _isEncrypted = true;
            _data = new InternalJson
            {
                Username = username,
                Password = password,
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
            public string Username;
            public string Password;
            public int Type;
            public int Platform;
            public int BuildId;

            public string ToJson()
            {
                var json = new JObject
                {
                    {"username", Username},
                    {"password", Password},
                    {"type", Type},
                    {"platform", Platform},
                    {"buildId", BuildId}
                };

                return json.ToString();
            }
        }
    }
}
