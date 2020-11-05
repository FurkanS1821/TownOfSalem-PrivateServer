using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class RemoveFriendMessage : BaseMessage
    {
        public readonly int AccountId;

        public RemoveFriendMessage(int accountId) : base(MessageType.RemoveFriend)
        {
            AccountId = accountId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(AccountId.ToString()));
        }
    }
}