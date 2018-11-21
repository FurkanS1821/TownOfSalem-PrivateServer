using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class NameChangeMessage : BaseMessage
    {
        public string Username;

        public NameChangeMessage(string username) : base(MessageType.NameChange)
        {
            Username = username.Trim();
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
