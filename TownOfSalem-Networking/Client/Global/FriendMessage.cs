using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendMessage : BaseMessage
    {
        public string FriendName;
        public string Message;

        public FriendMessage(byte[] data) : base(data)
        {
            try
            {
                var lines = BytesToString(data, 1).Split('*');
                FriendName = lines[0];
                Message = lines[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
