using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class DayTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public DayTargetMessage(int targetPosition) : base(MessageType.DayTarget)
        {
            TargetPosition = targetPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetPosition + 1));
        }
    }
}
