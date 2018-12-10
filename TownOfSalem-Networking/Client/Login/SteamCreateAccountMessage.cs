using System;
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

        public SteamCreateAccountMessage(byte[] data) : base(data)
        {
            try
            {
                var index = 1;
                var usernameLength = data[index++];
                var passwordLength = data[index++];
                var emailLength = data[index++];
                var referFriendLength = data[index++];

                Username = Encoding.UTF8.GetString(data, index, usernameLength);
                index += usernameLength;

                Password = Encoding.UTF8.GetString(data, index, passwordLength);
                index += passwordLength;

                Email = Encoding.UTF8.GetString(data, index, emailLength);
                index += emailLength;

                ReferFriendName = Encoding.UTF8.GetString(data, index, referFriendLength);
                index += referFriendLength;

                SteamAuthTicket = BytesToString(data, index);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
