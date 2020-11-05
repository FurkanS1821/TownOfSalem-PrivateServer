using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class ConfirmFriendRequestMessage : BaseMessage
    {
        public readonly int AccountId;
        public readonly ActivityStatus Status;
        public readonly bool Success;
        public readonly bool OwnsCoven;

        public ConfirmFriendRequestMessage(int accountId, ActivityStatus status, bool success, bool ownsCoven)
            : base(MessageType.ConfirmFriendRequest)
        {
            AccountId = accountId;
            Status = status;
            Success = success;
            OwnsCoven = ownsCoven;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(AccountId.ToString()));

            if (!Success)
            {
                return;
            }

            writer.Write('*');
            writer.Write((byte)Status);
            writer.Write('*');
            writer.Write((byte)(OwnsCoven ? 2 : 1));
        }
    }
}