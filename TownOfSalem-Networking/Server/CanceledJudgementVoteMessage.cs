using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CanceledJudgementVoteMessage : BaseMessage
    {
        public readonly int Position;

        public CanceledJudgementVoteMessage(int position) : base(MessageType.CanceledJudgementVote)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
