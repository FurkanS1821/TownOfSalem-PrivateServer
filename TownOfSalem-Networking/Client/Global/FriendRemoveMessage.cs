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
                var lines = BytesToString(data, 1).Split('*');
                AccountId = Convert.ToInt32(lines[0]);
                Name = lines[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
