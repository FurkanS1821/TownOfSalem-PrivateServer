using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Game
{
    public class PrivateMessage : BaseMessage
    {
        public int ToPosition;
        public string Message;

        public PrivateMessage(int toPosition, string message) : base(MessageType.PrivateMessage)
        {
            ToPosition = toPosition;
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(ToPosition + 1));
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
