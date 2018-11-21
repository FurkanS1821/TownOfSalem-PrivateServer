using System;

namespace TownOfSalem_Networking.Server
{
    public class AmbusherNightAbilityMessage : BaseMessage
    {
        public readonly int Position;

        public AmbusherNightAbilityMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
