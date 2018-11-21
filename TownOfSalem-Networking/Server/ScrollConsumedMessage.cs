using System;

namespace TownOfSalem_Networking.Server
{
    public class ScrollConsumedMessage : BaseMessage
    {
        public readonly int ScrollId;

        public ScrollConsumedMessage(byte[] data) : base(data)
        {
            try
            {
                ScrollId = int.Parse(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
