using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class ChangedJudgementVoteMessage : BaseMessage
    {
        public readonly int Position;

        public ChangedJudgementVoteMessage(int position) : base(MessageType.ChangedJudgementVote)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
