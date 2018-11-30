using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PartyMemberLeftMessage : BaseMessage
    {
        public readonly string Username;

        public PartyMemberLeftMessage(string username) : base(MessageType.PartyMemberLeft)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
