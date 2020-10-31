using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class GasDousedMessage : BaseMessage
    {
        public readonly int DouseType;
        public readonly int Position;

        public GasDousedMessage(int douseType, int position) : base(MessageType.GasDoused)
        {
            DouseType = douseType;
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(DouseType + 1));
            writer.Write((byte)(Position + 1));
        }
    }
}