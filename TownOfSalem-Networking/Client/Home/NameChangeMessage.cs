using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class NameChangeMessage : BaseMessage
    {
        public string Username;

        public NameChangeMessage(byte[] data) : base(data)
        {
            try
            {
                Username = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}