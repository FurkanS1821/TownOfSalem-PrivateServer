using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class SteamApproveMessage : BaseMessage
    {
        public string OrderId;

        public SteamApproveMessage(byte[] data) : base(data)
        {
            try
            {
                OrderId = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}