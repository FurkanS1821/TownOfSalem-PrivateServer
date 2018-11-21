using System;

namespace TownOfSalem_Networking.Server
{
    public class AddFriendRequestMessage : BaseMessage
    {
        public readonly bool Success;

        public AddFriendRequestMessage(byte[] data) : base(data)
        {
            try
            {
                Success = GetBoolValue(Convert.ToByte(data[1]));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
