using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class JesterCompletedGoalMessage : BaseMessage
    {
        public readonly List<int> NonInnocentPositions;

        public JesterCompletedGoalMessage(List<int> nonInnocentPositions) : base(MessageType.JesterCompletedGoal)
        {
            NonInnocentPositions = nonInnocentPositions;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var position in NonInnocentPositions)
            {
                writer.Write((byte)(position + 1));
            }
        }
    }
}