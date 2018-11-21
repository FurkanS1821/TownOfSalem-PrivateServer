using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class TauntTargetMessage : BaseMessage
    {
        public int Position;
        public int SubTarget;
        public int TauntId;

        public TauntTargetMessage(int position, int subTarget, int tauntId) : base(MessageType.TauntTarget)
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
