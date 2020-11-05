using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class JudgementVotedMessage : BaseMessage
    {
        public readonly int Position;

        public JudgementVotedMessage(int position) : base(MessageType.JudgementVoted)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}