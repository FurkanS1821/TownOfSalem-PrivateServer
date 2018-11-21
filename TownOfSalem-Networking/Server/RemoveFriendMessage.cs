using System;

namespace TownOfSalem_Networking.Server
{
    public class RemoveFriendMessage : BaseMessage
    {
        public readonly int AccountId;

        public RemoveFriendMessage(byte[] data) : base(data)
        {
            try
            {
                AccountId = int.Parse(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
