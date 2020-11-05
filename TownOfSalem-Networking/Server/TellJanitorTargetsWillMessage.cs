using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TellJanitorTargetsWillMessage : BaseMessage
    {
        public readonly int Position;
        public readonly string Will;

        public TellJanitorTargetsWillMessage(int position, string will) : base(MessageType.TellJanitorTargetsWill)
        {
            Position = position;
            Will = will;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write(Encoding.UTF8.GetBytes(Will));
        }
    }
}