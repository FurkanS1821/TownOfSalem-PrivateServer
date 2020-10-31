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
                var packet = BytesToString(data, 1).Split('*');
                FriendName = packet[0];
                Message = packet[1];
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}