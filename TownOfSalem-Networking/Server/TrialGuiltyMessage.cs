using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TrialGuiltyMessage : BaseMessage
    {
        public readonly int GuiltyVoteCount;
        public readonly int InnocentVoteCount;

        public TrialGuiltyMessage(int guiltyVoteCount, int innocentVoteCount) : base(MessageType.TrialGuilty)
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