using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class FriendListMessage : BaseMessage
    {
        public List<Friend> Friends;

        public FriendListMessage(List<Friend> friends) : base(MessageType.FriendList)
        {
            Friends = friends;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var packetData = new List<string>();
            foreach (var friend in Friends)
            {
                var friendData = $"{friend.UserName},{friend.AccountId},";
                friendData += (char)(byte)friend.Status + "," + (Convert.ToByte(friend.OwnsCoven) + 1);
                packetData.Add(friendData);
            }

            writer.Write(Encoding.UTF8.GetBytes(string.Join("*", packetData)));
        }
    }
}