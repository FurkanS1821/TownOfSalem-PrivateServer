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
            var packet = $"{Friend.UserName},{Friend.AccountId},{(byte)Friend.Status},";
            writer.Write(Encoding.UTF8.GetBytes(packet));
            writer.Write((byte)(Friend.OwnsCoven ? 2 : 1));
        }
    }
}