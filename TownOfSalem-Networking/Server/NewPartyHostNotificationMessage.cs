using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class NewPartyHostNotificationMessage : BaseMessage
    {
        public readonly string Username;

        public NewPartyHostNotificationMessage(string username) : base(MessageType.NewPartyHostNotification)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}