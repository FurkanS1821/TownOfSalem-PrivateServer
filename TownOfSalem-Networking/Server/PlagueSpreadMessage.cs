using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PlagueSpreadMessage : BaseMessage
    {
        public readonly int Position;

        public PlagueSpreadMessage(int position) : base(MessageType.PlagueSpread)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
