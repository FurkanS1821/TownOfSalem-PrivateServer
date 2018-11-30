using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PartyInvitePowerNotificationMessage : BaseMessage
    {
        public readonly string Username;

        public PartyInvitePowerNotificationMessage(string username) : base(MessageType.PartyInvitePowerNotification)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
