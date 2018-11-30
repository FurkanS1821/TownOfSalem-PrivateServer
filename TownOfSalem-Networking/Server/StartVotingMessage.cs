using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class StartVotingMessage : BaseMessage
    {
        public readonly int TimeRemainingSeconds;

        public StartVotingMessage(int timeRemainingSeconds) : base(MessageType.StartVoting)
        {
            TimeRemainingSeconds = timeRemainingSeconds;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)TimeRemainingSeconds);
        }
    }
}
