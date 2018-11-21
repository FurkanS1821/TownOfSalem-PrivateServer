using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class VoteTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public VoteTargetMessage(int targetPosition) : base(MessageType.VoteTarget)
        {
            TargetPosition = targetPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetPosition + 1));
        }
    }
}
