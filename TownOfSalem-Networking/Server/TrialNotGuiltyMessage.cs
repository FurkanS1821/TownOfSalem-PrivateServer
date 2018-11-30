using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TrialNotGuiltyMessage : BaseMessage
    {
        public readonly int GuiltyVoteCount;
        public readonly int InnocentVoteCount;

        public TrialNotGuiltyMessage(int guiltyVoteCount, int innocentVoteCount) : base(MessageType.TrialNotGuilty)
        {
            GuiltyVoteCount = guiltyVoteCount;
            InnocentVoteCount = innocentVoteCount;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(GuiltyVoteCount + 1));
            writer.Write((byte)(InnocentVoteCount + 1));
        }
    }
}
