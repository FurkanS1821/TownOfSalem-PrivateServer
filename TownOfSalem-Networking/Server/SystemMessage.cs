using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class SystemMessage : BaseMessage
    {
        public readonly string Message;

        public SystemMessage(string message) : base(MessageType.SystemMessage)
        {
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
