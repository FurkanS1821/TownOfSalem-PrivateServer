using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class VotedRepickHostMessage : BaseMessage
    {
        public readonly int VotesNeeded;

        public VotedRepickHostMessage(int votesNeeded) : base(MessageType.VotedRepickHost)
        {
            VotesNeeded = votesNeeded;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(VotesNeeded + 1));
        }
    }
}
