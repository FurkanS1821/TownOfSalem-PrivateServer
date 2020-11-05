using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class StartDayTransitionMessage : BaseMessage
    {
        public readonly List<int> DeadPositions;

        public StartDayTransitionMessage(List<int> deadPositions) : base(MessageType.StartDayTransition)
        {
            DeadPositions = deadPositions;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var position in DeadPositions)
            {
                writer.Write((byte)(position + 1));
            }
        }
    }
}