using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendConfirmMessage : BaseMessage
    {
        public int AccountId;
        public string Name;

        public FriendConfirmMessage(int accountId, string name) : base(MessageType.FriendConfirm)
        {
            AccountId = accountId;
            Name = name;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Name));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(AccountId.ToString()));
        }
    }
}
