using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyInviteMessage : BaseMessage
    {
        public string Username;

        public PartyInviteMessage(string username) : base(MessageType.PartyInvite)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
