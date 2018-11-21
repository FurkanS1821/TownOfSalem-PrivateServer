using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class FriendRequestNotificationMessage : BaseMessage
    {
        public List<FriendRequest> Notifications = new List<FriendRequest>();

        public FriendRequestNotificationMessage(byte[] data) : base(data)
        {
            try
            {
                var str1 = BytesToString(data, 1);
                foreach (var str2 in str1.Split('*'))
                {
                    var strArray = str2.Split(',');
                    Notifications.Add(new FriendRequest(strArray[0], int.Parse(strArray[1])));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
