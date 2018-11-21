using System;

namespace TownOfSalem_Networking.Server
{
    public class FacebookShareWinMessage : BaseMessage
    {
        public readonly int WinningGroupId;

        public FacebookShareWinMessage(byte[] data) : base(data)
        {
            try
            {
                WinningGroupId = Convert.ToInt32(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
