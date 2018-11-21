using System;

namespace TownOfSalem_Networking.Server
{
    public class FriendMessage : BaseMessage
    {
        public readonly int AccountId;
        public readonly bool IsSelfMessage;
        public readonly string Message;
        public readonly DateTime Timestamp;

        public FriendMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                AccountId = int.Parse(strArray[0]);
                IsSelfMessage = int.Parse(strArray[1]) == 1;
                Message = strArray[2];
                Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
