using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class UserLeftGameMessage : BaseMessage
    {
        public readonly bool ShouldRemoveFromLobby;
        public readonly bool ShouldUseAccountName;
        public readonly int Position;

        public UserLeftGameMessage(bool shouldRemoveFromLobby, bool shouldUseAccountName, int position)
            : base(MessageType.UserLeftGame)
        {
            ShouldRemoveFromLobby = shouldRemoveFromLobby;
            ShouldUseAccountName = shouldUseAccountName;
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(ShouldRemoveFromLobby ? 2 : 1));
            writer.Write((byte)(ShouldUseAccountName ? 2 : 1));
            writer.Write((byte)(Position + 1));
        }
    }
}
