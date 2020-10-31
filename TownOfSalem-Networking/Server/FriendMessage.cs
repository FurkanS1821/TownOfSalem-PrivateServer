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
            var packetContent = $"{AccountId}*{(IsSelfMessage ? 1 : 2)}*{Message}";
            writer.Write(Encoding.UTF8.GetBytes(packetContent));
        }
    }
}