using System.IO;
using Newtonsoft.Json.Linq;

namespace TownOfSalem_Networking.Client.Global
{
    public class RegisterAccountMessage : BaseMessage
    {
        protected InternalJson _data;

        public RegisterAccountMessage(string username, string password, string email, string referFriendName)
            : base(MessageType.RegisterAccount)
        {
            _isEncrypted = true;
            _data = new InternalJson
            {
                UserName = username,
                Password = password,
                Email = email,
                Referer = referFriendName
            };
        }

        public RegisterAccountMessage(string username, string password, string email, string referFriendName,
            string facebookId, string facebookToken) : this(username, password, email, referFriendName)
        {
            _data.FacebookId = facebookId;
            _data.FacebookToken = facebookToken;
        }

        public RegisterAccountMessage(string username, string password, string email, string referFriendName,
            string steamId) : this(username, password, email, referFriendName)
        {
            _data.SteamId = steamId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(_data.ToJson().ToCharArray());
        }

        protected class InternalJson
        {
            public string UserName;
            public string Password;
            public string Email;
            public string Referer;
            public string FacebookId;
            public string FacebookToken;
            public string SteamId;

            public string ToJson()
            {
                var json = new JObject
                {
                    {"username", UserName},
                    {"password", Password},
                    {"email", Email},
                    {"referer", Referer},
                    {"facebook_id", FacebookId},
                    {"facebook_token", FacebookToken},
                    {"steam_id", SteamId}
                };

                return json.ToString();
            }
        }
    }
}
