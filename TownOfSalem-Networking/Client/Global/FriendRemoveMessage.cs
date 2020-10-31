using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendRemoveMessage : BaseMessage
    {
        public int AccountId;
        public string Name;

        public FriendRemoveMessage(byte[] data) : base(data)
        {
            try
            {
                var packet = BytesToString(data, 1).Split('*');
                AccountId = Convert.ToInt32(packet[1]);
                Name = packet[0];
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}