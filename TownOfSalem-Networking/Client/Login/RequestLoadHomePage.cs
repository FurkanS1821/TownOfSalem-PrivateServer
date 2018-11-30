using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Client.Login
{
    public class RequestLoadHomePage : BaseMessage
    {
        private LoginType _loginType;
        private string _username;
        private string _password;
        private int _flags;
        private int _buildId;
        private Platform _platform;

        public RequestLoadHomePage(byte[] data) : base(data)
        {
            try
            {
                var index = 1;
                _loginType = (LoginType)data[index++];
                _flags = data[index++] - 1;
                _platform = (Platform)data[index++];

                var buildBytes = new List<byte>();
                while (true)
                {
                    if (data[index] == 30)
                    {
                        index++;
                        break;
                    }

                    buildBytes.Add(data[index++]);
                }
                _buildId = Convert.ToInt32(BytesToString(buildBytes.ToArray()));

                var usernameBytes = new List<byte>();
                while (true)
                {
                    if (data[index] == 30)
                    {
                        index++;
                        break;
                    }

                    usernameBytes.Add(data[index++]);
                }
                _username = BytesToString(usernameBytes.ToArray());

                _password = Crypto.PrivateKeyDecrypt(BytesToString(data, index));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
