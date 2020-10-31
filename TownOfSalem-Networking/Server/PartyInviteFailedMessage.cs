using System;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteFailedMessage : BaseMessage
    {
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
            var status = string.Empty;
            switch (Status)
            {
                case PartyMemberInviteStatus.Locale:
                    status = "1";
                    break;
                case PartyMemberInviteStatus.NoCoven:
                    status = "3";
                    break;
                default:
                    throw new ArgumentException();
            }

            writer.Write(Encoding.UTF8.GetBytes($"{Username}*{status}"));
            
        }
    }
}