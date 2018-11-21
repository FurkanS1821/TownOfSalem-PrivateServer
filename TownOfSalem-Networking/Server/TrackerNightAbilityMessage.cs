using System;

namespace TownOfSalem_Networking.Server
{
    public class TrackerNightAbilityMessage : BaseMessage
    {
        public readonly int Position;

        public TrackerNightAbilityMessage(byte[] data) : base(data)
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
