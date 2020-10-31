using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class IdentifyMessage : BaseMessage
    {
        public readonly string Message;

        public IdentifyMessage(string message) : base(MessageType.IdentifyMessage)
        {
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}