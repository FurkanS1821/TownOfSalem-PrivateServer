using System;

namespace TownOfSalem_Networking.Server
{
    public class SpyNightInfoMessage : BaseMessage
    {
        public readonly int[] SpyMessageIds;

        public SpyNightInfoMessage(byte[] data) : base(data)
        {
            try
            {
                SpyMessageIds = new int[data.Length - 1];
                for (var i = 1; i < data.Length; ++i)
                {
                    SpyMessageIds[i - 1] = data[i] - 1;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
