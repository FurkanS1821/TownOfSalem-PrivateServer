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
                var lines = BytesToString(data, 1).Split(new[] {'*'}, 2);
                Name = lines[0];
                AccountId = Convert.ToInt32(lines[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
