using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class PendingPartyInviteStatusMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PendingPartyInviteStatusMessage(PartyMemberInviteStatus status, string username)
            : base(MessageType.PendingPartyInviteStatus)
        {
            Status = status;
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write('*');
            writer.Write((byte)Status);
        }
    }
}
