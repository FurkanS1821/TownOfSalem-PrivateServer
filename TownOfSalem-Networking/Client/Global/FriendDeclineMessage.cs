using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendDeclineMessage : BaseMessage
    {
        public int AccountId;

        public FriendDeclineMessage(byte[] data) : base(data)
        {
            try
            {
                AccountId = Convert.ToInt32(BytesToString(data, 1));
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}