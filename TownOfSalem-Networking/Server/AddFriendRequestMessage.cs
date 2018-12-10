using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AddFriendRequestMessage : BaseMessage
    {
        public readonly bool Success;

        public AddFriendRequestMessage(bool success) : base(MessageType.AddFriendRequest)
        {
            Success = success;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Success ? 2 : 1));
        }
    }
}
