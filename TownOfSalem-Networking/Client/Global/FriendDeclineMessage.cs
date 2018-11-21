using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendDeclineMessage : BaseMessage
    {
        public int AccountId;

        public FriendDeclineMessage(int accountId) : base(MessageType.FriendDecline)
        {
            AccountId = accountId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(AccountId.ToString()));
        }
    }
}
