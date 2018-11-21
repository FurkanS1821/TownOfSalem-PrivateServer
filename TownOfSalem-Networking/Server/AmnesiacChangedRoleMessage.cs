using System;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacChangedRoleMessage : BaseMessage
    {
        public readonly int RoleId;

        public AmnesiacChangedRoleMessage(byte[] data) : base(data)
        {
            try
            {
                RoleId = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
