using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TellJudgementVotesMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int Vote;

        public TellJudgementVotesMessage(int position, int vote) : base(MessageType.TellJudgementVotes)
        {
            Position = position;
            Vote = vote;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)Vote);
        }
    }
}
