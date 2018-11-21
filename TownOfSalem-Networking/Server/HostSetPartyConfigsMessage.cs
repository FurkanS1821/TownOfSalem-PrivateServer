using System;

namespace TownOfSalem_Networking.Server
{
    public class HostSetPartyConfigsMessage : BaseMessage
    {
        public readonly int Brand;
        public readonly int GameMode;
        public readonly int Result;

        public HostSetPartyConfigsMessage(byte[] data) : base(data)
        {
            try
            {
                Brand = data[1] - 1;
                GameMode = data[2] - 1;
                Result = data[3] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
