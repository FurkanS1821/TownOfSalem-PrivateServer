using System;

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

                Username = BytesToString(data, index, usernameLength);
                index += usernameLength;

                Password = BytesToString(data, index, passwordLength);
                index += passwordLength;

                Email = BytesToString(data, index, emailLength);
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
