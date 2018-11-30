using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PartyMemberKickedMessage : BaseMessage
    {
        public readonly string Username;

        public PartyMemberKickedMessage(string username) : base(MessageType.PartyMemberKicked)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
