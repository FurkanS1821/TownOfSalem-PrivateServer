using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TauntResultMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int SubTarget;
        public readonly int TauntId;
        public readonly int Result;

        public TauntResultMessage(int position, int subTarget, int tauntId, int result) : base(MessageType.TauntResult)
        {
            Position = position;
            SubTarget = subTarget;
            TauntId = tauntId;
            Result = result;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(SubTarget + 1));
            writer.Write((byte)(TauntId + 1));
            writer.Write((byte)(Result + 1));
        }
    }
}
