using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class FriendListMessage : BaseMessage
    {
        public List<Friend> Friends = new List<Friend>();

        public FriendListMessage(byte[] data) : base(data)
        {
            try
            {
                if (data.Length <= 1)
                {
                    return;
                }

                var str1 = BytesToString(data, 1);
                foreach (var str2 in str1.Split('*'))
                {
                    var strArray = str2.Split(',');
                    Friends.Add(new Friend(
                        strArray[0],
                        int.Parse(strArray[1]),
                        (ActivityStatus)strArray[2][0],
                        Convert.ToBoolean(int.Parse(strArray[3]) - 1)
                    ));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
