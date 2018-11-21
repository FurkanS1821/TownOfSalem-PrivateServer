using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class NightTargetSecondMessage : BaseMessage
    {
        public int TargetPosition;

        public NightTargetSecondMessage(int targetPosition) : base(MessageType.NightTargetSecond)
        {
            TargetPosition = targetPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetPosition + 1));
        }
    }
}
