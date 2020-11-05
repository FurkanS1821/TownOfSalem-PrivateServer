using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class VampireVisitedMessage : BaseMessage
    {
        public readonly int Position;

        public VampireVisitedMessage(int position) : base(MessageType.VampireVisitedMessage)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}