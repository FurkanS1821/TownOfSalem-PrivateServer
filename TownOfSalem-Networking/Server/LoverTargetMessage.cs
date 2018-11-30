using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class LoverTargetMessage : BaseMessage
    {
        public readonly int Position;

        public LoverTargetMessage(int position) : base(MessageType.LoverTarget)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
