using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DisguiserChangedUpdateMafiaMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int PreviousPosition;

        public DisguiserChangedUpdateMafiaMessage(int position, int previousPosition)
            : base(MessageType._UNUSED_DisguiserChangedUpdateMafia)
        {
            Position = position;
            PreviousPosition = previousPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(PreviousPosition + 1));
        }
    }
}
