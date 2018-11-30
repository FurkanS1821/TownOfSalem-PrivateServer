using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class VIPPlayerMessage : BaseMessage
    {
        public readonly int Position;

        public VIPPlayerMessage(int position) : base(MessageType.VIPPlayer)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
