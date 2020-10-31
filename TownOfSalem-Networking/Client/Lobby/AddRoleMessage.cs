using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class AddRoleMessage : BaseMessage
    {
        public int RoleIndex;

        public AddRoleMessage(byte[] data) : base(data)
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