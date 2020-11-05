using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Structs;

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
            var list = Notifications.Select(x => $"{x.UserName},{x.AccountId}");
            writer.Write(Encoding.UTF8.GetBytes(string.Join("*", list)));
        }
    }
}