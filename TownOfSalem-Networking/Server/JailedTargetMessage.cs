using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class JailedTargetMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasExecutionsRemaining;
        public readonly bool HasKilledTown;

        public JailedTargetMessage(int position, bool hasExecutionsRemaining, bool hasKilledTown)
            : base(MessageType.JailedTarget)
        {
            Position = position;
            HasExecutionsRemaining = hasExecutionsRemaining;
            HasKilledTown = hasKilledTown;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(HasExecutionsRemaining ? 2 : 0));
            writer.Write((byte)(HasKilledTown ? 2 : 0));
        }
    }
}
