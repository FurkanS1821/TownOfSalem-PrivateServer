using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Login
{
    public class SteamCreateAccountMessage : BaseMessage
    {
        public string Username;
        public string Password;
        public string Email;
        public string ReferFriendName;
        public string SteamAuthTicket;

        public SteamCreateAccountMessage(string username, string password, string email, string referFriendName,
            string steamAuthTicket) : base(MessageType.SteamCreateAccount)
        {
            Username = username;
            Password = password;
            Email = email;
            ReferFriendName = referFriendName;
            SteamAuthTicket = steamAuthTicket;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Encoding.UTF8.GetByteCount(Username));
            writer.Write((byte)Encoding.UTF8.GetByteCount(Password));
            writer.Write((byte)Encoding.UTF8.GetByteCount(Email));
            writer.Write((byte)Encoding.UTF8.GetByteCount(ReferFriendName));
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write(Encoding.UTF8.GetBytes(Password));
            writer.Write(Encoding.UTF8.GetBytes(Email));
            writer.Write(Encoding.UTF8.GetBytes(ReferFriendName));
            writer.Write(Encoding.UTF8.GetBytes(SteamAuthTicket));
        }
    }
}
