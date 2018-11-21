using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Login
{
    public class FBCreateAccountMessage : BaseMessage
    {
        public string Username;
        public string Password;
        public string Email;
        public string ReferFriendName;

        public FBCreateAccountMessage(string username, string password, string email, string referFriendName)
            : base(MessageType.FBCreateAccount)
        {
            Username = username;
            Password = password;
            Email = email;
            ReferFriendName = referFriendName;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Encoding.UTF8.GetByteCount(Username) + 1));
            writer.Write((byte)(Encoding.UTF8.GetByteCount(Password) + 1));
            writer.Write((byte)(Encoding.UTF8.GetByteCount(Email) + 1));
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write(Encoding.UTF8.GetBytes(Password));
            writer.Write(Encoding.UTF8.GetBytes(Email));
            writer.Write(Encoding.UTF8.GetBytes(ReferFriendName));
        }
    }
}
