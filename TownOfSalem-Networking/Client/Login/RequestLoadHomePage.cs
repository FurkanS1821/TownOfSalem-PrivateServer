using System;

namespace TownOfSalem_Networking.Client.Login
{
    public class RequestLoadHomePage : BaseMessage
    {
        public LoginType LoginType;
        public string Username;
        public string SteamId;
        public string PasswordEncrypted;
        public int Flags;
        public int BuildId;
        public Platform Platform;

        public RequestLoadHomePage(byte[] data) : base(data)
        {
            try
            {
                LoginType = (LoginType)data[1];
                Flags = data[2] - 1;
                Platform = (Platform)data[3];

                var str = BytesToString(data, 4).Split('\u001E');
                var index = 0;
                BuildId = Convert.ToInt32(str[index++]);
                Username = str[index++];

                if (Platform == Platform.STEAM)
                {
                    SteamId = str[index++];
                }

                PasswordEncrypted = str[index];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
