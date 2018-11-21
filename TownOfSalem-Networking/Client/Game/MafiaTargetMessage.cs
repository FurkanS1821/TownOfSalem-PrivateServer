using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class MafiaTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public MafiaTargetMessage(int targetPosition) : base(MessageType.MafiaTarget)
        {
            TargetPosition = targetPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetPosition + 1));
        }
    }
}
