using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class UserLeftDuringSelectionMessage : BaseMessage
    {
        public readonly int Position;

        public UserLeftDuringSelectionMessage(int position) : base(MessageType.UserLeftDuringSelection)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
