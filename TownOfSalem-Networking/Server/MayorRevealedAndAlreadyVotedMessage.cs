using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class MayorRevealedAndAlreadyVotedMessage : BaseMessage
    {
        public readonly int Position;

        public MayorRevealedAndAlreadyVotedMessage(int position) : base(MessageType.MayorRevealedAndAlreadyVoted)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
