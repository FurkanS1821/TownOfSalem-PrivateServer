using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendMessage : BaseMessage
    {
        public string FriendName;
        public string Message;

        public FriendMessage(string friendName, string message) : base(MessageType.FriendMessage)
        {
            FriendName = friendName;
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(FriendName));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
