using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendAddMessage : BaseMessage
    {
        public string FriendName;

        public FriendAddMessage(byte[] data) : base(data)
        {
            try
            {
                FriendName = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
