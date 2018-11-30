using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class RequestRankedGameMessage : BaseMessage
    {
        public int GameMode;

        public RequestRankedGameMessage(byte[] data) : base(data)
        {
            try
            {
                GameMode = data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
