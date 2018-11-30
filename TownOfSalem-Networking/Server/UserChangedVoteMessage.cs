using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class UserChangedVoteMessage : BaseMessage
    {
        public readonly int SourcePosition;
        public readonly int TargetPosition;
        public readonly int PreviousTargetPosition;
        public readonly int VoteCount;

        public UserChangedVoteMessage(int sourcePosition, int targetPosition, int previousTargetPosition, int voteCount)
            : base(MessageType.UserChangedVote)
        {
            SourcePosition = sourcePosition;
            TargetPosition = targetPosition;
            PreviousTargetPosition = previousTargetPosition;
            VoteCount = voteCount;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(SourcePosition + 1));
            writer.Write((byte)(TargetPosition + 1));
            writer.Write((byte)(PreviousTargetPosition + 1));
            writer.Write((byte)VoteCount);
        }
    }
}
