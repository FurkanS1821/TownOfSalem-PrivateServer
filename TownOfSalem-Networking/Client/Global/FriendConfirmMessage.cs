using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class FriendConfirmMessage : BaseMessage
    {
        public int AccountId;
        public string Name;

        public FriendConfirmMessage(byte[] data) : base(data)
        {
            try
            {
                var packet = BytesToString(data, 1).Split('*');

                Name = packet[0];
                AccountId = Convert.ToInt32(packet[1]);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}