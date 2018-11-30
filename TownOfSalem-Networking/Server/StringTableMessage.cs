using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class StringTableMessage : BaseMessage
    {
        public readonly int StringTableId;

        public StringTableMessage(int stringTableId) : base(MessageType.StringTableMessage)
        {
            StringTableId = stringTableId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(StringTableId + 1));
        }
    }
}
