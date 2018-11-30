using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class UserDisconnectedMessage : BaseMessage
    {
        public readonly int Position;

        public UserDisconnectedMessage(int position) : base(MessageType.UserDisconnected)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
