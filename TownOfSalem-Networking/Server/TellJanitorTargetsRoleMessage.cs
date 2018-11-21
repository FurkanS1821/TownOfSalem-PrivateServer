using System;

namespace TownOfSalem_Networking.Server
{
    public class TellJanitorTargetsRoleMessage : BaseMessage
    {
        public readonly int Role;

        public TellJanitorTargetsRoleMessage(byte[] data) : base(data)
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
