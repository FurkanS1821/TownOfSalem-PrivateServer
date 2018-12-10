using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AddVampireMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool IsYoungest;

        public AddVampireMessage(int position, bool isYoungest) : base(MessageType.AddVampire)
        {
            Position = position;
            IsYoungest = isYoungest;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(IsYoungest ? 2 : 1));
        }
    }
}
