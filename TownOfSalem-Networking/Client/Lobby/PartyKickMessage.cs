using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyKickMessage : BaseMessage
    {
        public string Username;

        public PartyKickMessage(string username) : base(MessageType.PartyKick)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
