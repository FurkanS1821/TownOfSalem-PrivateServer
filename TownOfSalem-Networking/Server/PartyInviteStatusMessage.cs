using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteStatusMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PartyInviteStatusMessage(PartyMemberInviteStatus status, string username) : base(0) // todo
        {
            Status = status;
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(((byte)Status).ToString()));
        }
    }
}
