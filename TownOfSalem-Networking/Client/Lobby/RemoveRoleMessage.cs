using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class RemoveRoleMessage : BaseMessage
    {
        public int RoleIndex;

        public RemoveRoleMessage(byte[] data) : base(data)
        {
            try
            {
                RoleIndex = data[1] - 1;
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}