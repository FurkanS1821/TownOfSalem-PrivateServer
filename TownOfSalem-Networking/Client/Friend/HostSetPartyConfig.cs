using System;

namespace TownOfSalem_Networking.Client.Friend
{
    public class HostSetPartyConfig : BaseMessage
    {
        public int Brand;
        public int GameMode;

        public HostSetPartyConfig(byte[] data) : base(data)
        {
            try
            {
                Brand = data[1] - 1;
                GameMode = data[2] - 1;
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}