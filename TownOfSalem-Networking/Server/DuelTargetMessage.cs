using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DuelTargetMessage : BaseMessage
    {
        public readonly int Position;

        public DuelTargetMessage(int position) : base(MessageType.DuelTarget)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
