using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ChatBoxMessage : BaseMessage
    {
        public readonly int Source = -1;
        public readonly int Position;
        public readonly string Text;
        public readonly bool UseAccountName;

        public ChatBoxMessage(int source, int position, string text, bool useAccountName)
            : base(MessageType.ChatBoxMessage)
        {
            Source = source;
            Position = position;
            Text = text;
            UseAccountName = useAccountName;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            if (UseAccountName)
            {
                writer.Write(byte.MaxValue);
                writer.Write((byte)(Position + 1));
            }
            else
            {
                writer.Write((byte)(Source + 1));
            }

            writer.Write(Encoding.UTF8.GetBytes(Text));
        }
    }
}
