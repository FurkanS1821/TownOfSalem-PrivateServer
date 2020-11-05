using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class CheckUsernameMessage : BaseMessage
    {
        public string Username;

        public CheckUsernameMessage(byte[] data) : base(data)
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