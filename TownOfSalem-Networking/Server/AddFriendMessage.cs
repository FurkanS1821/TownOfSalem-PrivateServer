using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class AddFriendMessage : BaseMessage
    {
        public readonly Friend Friend;

        public AddFriendMessage(Friend friend) : base(MessageType.AddFriend)
        {
            Friend = friend;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Friend.UserName));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Friend.AccountId.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(((byte)Friend.Status).ToString()));
            writer.Write(',');
            writer.Write((byte)(Friend.OwnsCoven ? 2 : 1));
        }
    }
}
