using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class ChatMessage : BaseMessage
    {
        public string Message;

        public ChatMessage(string message) : base(MessageType.ChatMessage)
        {
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
