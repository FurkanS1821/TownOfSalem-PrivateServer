using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PartyChatMessage : BaseMessage
    {
        public readonly string From;
        public readonly string Message;

        public PartyChatMessage(string from, string message) : base(MessageType.PartyChatMessage)
        {
            From = from;
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(From));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
