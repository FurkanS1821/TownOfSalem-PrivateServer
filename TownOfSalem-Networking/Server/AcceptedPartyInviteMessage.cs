using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AcceptedPartyInviteMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;

        public AcceptedPartyInviteMessage(PartyMemberInviteStatus status) : base(MessageType.AcceptedPartyInvite)
        {
            Status = status;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Status);
        }
    }
}
