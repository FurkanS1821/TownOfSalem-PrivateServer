using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteStatusMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PartyInviteStatusMessage(PartyMemberInviteStatus status, string username)
            : base(MessageType.PendingPartyInviteStatus)
        {
            Status = status;
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
            if (Status != 0)
            {
                writer.Write(Encoding.UTF8.GetBytes($"*{(byte)Status}"));
            }
        }
    }
}