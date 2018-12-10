using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class FriendUpdateMessage : BaseMessage
    {
        public readonly int AccountId;
        public readonly ActivityStatus Status;
        public readonly bool OwnsCoven;

        public FriendUpdateMessage(int accountId, ActivityStatus status, bool ownsCoven)
            : base(MessageType.FriendUpdate)
        {
            AccountId = accountId;
            Status = status;
            OwnsCoven = ownsCoven;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(AccountId.ToString()));
            writer.Write('*');
            writer.Write((byte)Status);
            writer.Write('*');
            writer.Write((byte)(OwnsCoven ? 2 : 1));
        }
    }
}
