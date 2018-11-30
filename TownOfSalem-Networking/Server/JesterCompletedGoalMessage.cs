using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class JesterCompletedGoalMessage : BaseMessage
    {
        public readonly List<int> GuiltyVotePositions;

        public JesterCompletedGoalMessage(List<int> guiltyVotePositions) : base(MessageType.JesterCompletedGoal)
        {
            GuiltyVotePositions = guiltyVotePositions;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var guiltyVote in GuiltyVotePositions)
            {
                writer.Write((byte)(guiltyVote + 1));
            }
        }
    }
}
