using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TellLastWillMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly string WillText;

        public TellLastWillMessage(int position, bool hasLastWill, string willText) : base(MessageType.TellLastWill)
        {
            Position = position;
            HasLastWill = hasLastWill;
            WillText = willText;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(HasLastWill ? 2 : 1));

            if (!HasLastWill)
            {
                return;
            }

            writer.Write(Encoding.UTF8.GetBytes(WillText));
        }
    }
}
