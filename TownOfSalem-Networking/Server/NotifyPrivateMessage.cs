using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class NotifyPrivateMessage : BaseMessage
    {
        public readonly int FromPosition;
        public readonly int ToPosition;

        public NotifyPrivateMessage(int fromPosition, int toPosition) : base(MessageType.NotifyPrivateMessage)
        {
            FromPosition = fromPosition;
            ToPosition = toPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(FromPosition + 1));
            writer.Write((byte)(ToPosition + 1));
        }
    }
}
