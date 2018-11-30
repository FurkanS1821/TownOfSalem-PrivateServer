using System;

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

                Username = BytesToString(data, index, usernameLength);
                index += usernameLength;

                Password = BytesToString(data, index, passwordLength);
                index += passwordLength;

                Email = BytesToString(data, index, emailLength);
                index += emailLength;

                ReferFriendName = BytesToString(data, index, referFriendLength);
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
