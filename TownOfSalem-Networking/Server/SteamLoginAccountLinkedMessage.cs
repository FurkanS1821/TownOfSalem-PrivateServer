using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class SteamLoginAccountLinkedMessage : BaseMessage
    {
        public readonly string Username;

        public SteamLoginAccountLinkedMessage(string username) : base(MessageType.SteamLoginAccountLinked)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
