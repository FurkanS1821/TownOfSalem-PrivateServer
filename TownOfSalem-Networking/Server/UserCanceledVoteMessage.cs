using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class UserCanceledVoteMessage : BaseMessage
    {
        public readonly int SourcePosition;
        public readonly int TargetPosition;
        public readonly int VoteCount;

        public UserCanceledVoteMessage(int sourcePosition, int targetPosition, int voteCount)
            : base(MessageType.UserCanceledVote)
        {
            SourcePosition = sourcePosition;
            TargetPosition = targetPosition;
            VoteCount = voteCount;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(SourcePosition + 1));
            writer.Write((byte)(TargetPosition + 1));
            writer.Write((byte)VoteCount);
        }
    }
}
