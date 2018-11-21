using System;

namespace TownOfSalem_Networking.Server
{
    public class TrapperNightAbilityMessage : BaseMessage
    {
        public readonly int RoleId;

        public TrapperNightAbilityMessage(byte[] data) : base(data)
        {
            try
            {
                RoleId = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
