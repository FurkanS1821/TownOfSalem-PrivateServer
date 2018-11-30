using System;

namespace TownOfSalem_Networking.Client.Login
{
    public class SteamLinkAccount : BaseMessage
    {
        public string Username;
        public string Password;
        public string SteamId;

        public SteamLinkAccount(byte[] data) : base(data)
        {
            try
            {
                var index = 1;
                var usernameLength = data[index++];
                var passwordLength = data[index++];

                Username = BytesToString(data, index, usernameLength);
                index += usernameLength;

                Password = BytesToString(data, index, passwordLength);
                index += passwordLength;

                SteamId = BytesToString(data, index);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
