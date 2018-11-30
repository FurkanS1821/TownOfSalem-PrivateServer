using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TauntActivatedMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int SubTarget;
        public readonly int TauntId;

        public TauntActivatedMessage(int position, int subTarget, int tauntId) : base(MessageType.TauntActivated)
        {
            Position = position;
            SubTarget = subTarget;
            TauntId = tauntId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(SubTarget + 1));
            writer.Write((byte)(TauntId + 1));
        }
    }
}
