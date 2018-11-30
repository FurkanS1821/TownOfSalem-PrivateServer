using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PrivateMessage : BaseMessage
    {
        public readonly int SourceType;
        public readonly int Position;
        public readonly int Position2;
        public readonly string Message;

        public PrivateMessage(int sourceType, int position, int position2, string message)
            : base(MessageType.PrivateMessage)
        {
            SourceType = sourceType;
            Position = position;
            Position2 = position2;
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)SourceType);
            writer.Write((byte)(Position + 1));

            if (SourceType == 3)
            {
                writer.Write((byte)(Position2 + 1));
            }

            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
