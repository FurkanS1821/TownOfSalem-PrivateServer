using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendAddMessage : BaseMessage
    {
        public string FriendName;

        public FriendAddMessage(string friendName) : base(MessageType.FriendAdd)
        {
            FriendName = friendName;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(FriendName));
        }
    }
}
