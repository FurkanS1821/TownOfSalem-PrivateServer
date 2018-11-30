using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class FriendRequestNotificationMessage : BaseMessage
    {
        public List<FriendRequest> Notifications;

        public FriendRequestNotificationMessage(List<FriendRequest> notifications)
            : base(MessageType.FriendRequestNotification)
        {
            Notifications = notifications;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Notifications.Count; i++)
            {
                var notification = Notifications[i];

                writer.Write(Encoding.UTF8.GetBytes(notification.UserName));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(notification.AccountId.ToString()));

                if (i < Notifications.Count - 1)
                {
                    writer.Write('*');
                }
            }
        }
    }
}
