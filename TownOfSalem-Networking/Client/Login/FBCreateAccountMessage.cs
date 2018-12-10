using System;
using System.Text;

namespace TownOfSalem_Networking.Client.Login
{
    public class FBCreateAccountMessage : BaseMessage
    {
        public string Username;
        public string Password;
        public string Email;
        public string ReferFriendName;

        public FBCreateAccountMessage(byte[] data) : base(data)
        {
            try
            {
                var index = 1;
                var usernameLength = data[index++] - 1;
                var passwordLength = data[index++] - 1;
                var emailLength = data[index++] - 1;

                Username = Encoding.UTF8.GetString(data, index, usernameLength);
                index += usernameLength;

                Password = Encoding.UTF8.GetString(data, index, passwordLength);
                index += passwordLength;

                Email = Encoding.UTF8.GetString(data, index, emailLength);
                index += emailLength;

                ReferFriendName = BytesToString(data, index);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
