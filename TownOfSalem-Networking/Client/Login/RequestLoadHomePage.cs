using System;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Client.Login
{
    public class RequestLoadHomePage : BaseMessage
    {
        public LoginType LoginType;
        public string Username;
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
                var packet = BytesToString(data, 4).Split('\x1E');
                BuildId = Convert.ToInt32(packet[0]);
                Username = packet[1];
                PasswordEncrypted = packet[2];
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}