using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class NightTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public NightTargetMessage(int targetPosition) : base(MessageType.NightTarget)
        {
            TargetPosition = targetPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetPosition + 1));
        }
    }
}
