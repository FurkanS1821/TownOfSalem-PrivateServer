using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class MafiaWasJailedMessage : BaseMessage
    {
        public readonly int Position;

        public MafiaWasJailedMessage(int position) : base(MessageType.MafiaWasJailed)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
