using System;

namespace TownOfSalem_Networking.Server
{
    public class TellTownAmnesiacChangedRoleMessage : BaseMessage
    {
        public readonly int Role;

        public TellTownAmnesiacChangedRoleMessage(byte[] data) : base(data)
        {
            try
            {
                Role = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
