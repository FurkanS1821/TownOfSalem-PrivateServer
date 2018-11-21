using System;

namespace TownOfSalem_Networking.Server
{
    public class FriendsNewUsernameMessage : BaseMessage
    {
        public readonly string OldUsername;
        public readonly string NewUsername;

        public FriendsNewUsernameMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data).Split('*');
                OldUsername = strArray[0];
                NewUsername = strArray[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
