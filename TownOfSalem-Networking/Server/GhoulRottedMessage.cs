using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class GhoulRottedMessage : BaseMessage
    {
        public readonly int Position;

        public GhoulRottedMessage(int position) : base(MessageType.GhoulRotted)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}