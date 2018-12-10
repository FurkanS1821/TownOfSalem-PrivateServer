using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class FriendMessage : BaseMessage
    {
        public readonly int AccountId;
        public readonly bool IsSelfMessage;
        public readonly string Message;

        public FriendMessage(int accountId, bool isSelfMessage, string message) : base(MessageType.FriendMessage)
        {
            AccountId = accountId;
            IsSelfMessage = isSelfMessage;
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(AccountId.ToString()));
            writer.Write('*');
            writer.Write((byte)(IsSelfMessage ? 1 : 2));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
