using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteNotificationMessage : BaseMessage
    {
        public readonly PartyInvite PartyInvite;

        public PartyInviteNotificationMessage(PartyInvite partyInvite) : base(MessageType.PartyInviteNotification)
        {
            PartyInvite = partyInvite;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes($"{PartyInvite.PartyId}*{PartyInvite.HostUsername}"));
        }
    }
}