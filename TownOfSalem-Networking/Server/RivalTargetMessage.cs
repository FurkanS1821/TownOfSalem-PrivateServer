using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class RivalTargetMessage : BaseMessage
    {
        public readonly int Position;

        public RivalTargetMessage(int position) : base(MessageType.RivalTarget)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}