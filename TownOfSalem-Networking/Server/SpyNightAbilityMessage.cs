using System;

namespace TownOfSalem_Networking.Server
{
    public class SpyNightAbilityMessage : BaseMessage
    {
        public readonly int Type;
        public readonly int Position;

        public SpyNightAbilityMessage(byte[] data) : base(data)
        {
            try
            {
                Type = data[1];
                Position = data[2] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
