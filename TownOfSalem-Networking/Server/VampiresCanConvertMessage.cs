using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class VampiresCanConvertMessage : BaseMessage
    {
        public readonly bool CanConvert;

        public VampiresCanConvertMessage(bool canConvert) : base(MessageType.VampiresCanConvert)
        {
            CanConvert = canConvert;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(CanConvert ? 2 : 0));
        }
    }
}
