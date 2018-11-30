using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteFailedMessage : BaseMessage
    {
        private Dictionary<PartyMemberInviteStatus, string> _lookup = new Dictionary<PartyMemberInviteStatus, string>
        {
            {PartyMemberInviteStatus.Locale, "1"},
            {PartyMemberInviteStatus.NoCoven, "3"}
        };

        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PartyInviteFailedMessage(PartyMemberInviteStatus status, string username)
            : base(MessageType.PartyInviteFailed)
        {
            Status = status;
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write('*');

            if (!_lookup.ContainsKey(Status))
            {
                return;
            }

            writer.Write(Encoding.UTF8.GetBytes(_lookup[Status]));
        }
    }
}
