using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Login
{
    public class SteamLinkAccount : BaseMessage
    {
        public string Username;
        public string Password;
        public string SteamId;

        public SteamLinkAccount(string username, string password, string steamId) : base(MessageType.SteamLinkAccount)
        {
            Username = username;
            Password = password;
            SteamId = steamId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Encoding.UTF8.GetByteCount(Username));
            writer.Write((byte)Encoding.UTF8.GetByteCount(Password));
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write(Encoding.UTF8.GetBytes(Password));
            writer.Write(Encoding.UTF8.GetBytes(SteamId));
        }
    }
}
