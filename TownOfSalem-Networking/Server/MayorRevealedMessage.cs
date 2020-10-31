using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class MayorRevealedMessage : BaseMessage
    {
        public readonly int Position;

        public MayorRevealedMessage(int position) : base(MessageType.MayorRevealed)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}