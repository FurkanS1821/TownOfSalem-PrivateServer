using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class PartyMessage : BaseMessage
    {
        public string Message;

        public PartyMessage(string message) : base(MessageType.PartyMessage)
        {
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
