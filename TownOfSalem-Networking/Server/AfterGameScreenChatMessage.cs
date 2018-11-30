using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class AfterGameScreenChatMessage : BaseMessage
    {
        public readonly int Position;
        public readonly string Message;

        public AfterGameScreenChatMessage(int position, string message) : base(MessageType.AfterGameScreenChat)
        {
            Position = position;
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
