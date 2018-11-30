using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class InvalidNameMessage : BaseMessage
    {
        public readonly int Reason;

        public InvalidNameMessage(int reason) : base(MessageType.InvalidName)
        {
            Reason = reason;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Reason);
        }
    }
}
