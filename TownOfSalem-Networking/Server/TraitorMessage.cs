using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TraitorMessage : BaseMessage
    {
        public readonly int Position;

        public TraitorMessage(int position) : base(MessageType.TraitorPlayer)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}