using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyGiveInvitePrivilegesMessage : BaseMessage
    {
        public string Username;

        public PartyGiveInvitePrivilegesMessage(string username) : base(MessageType.PartyGiveInvitePrivileges)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
