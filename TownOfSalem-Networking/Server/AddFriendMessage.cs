using System;

namespace TownOfSalem_Networking.Server
{
    public class AddFriendMessage : BaseMessage
    {
        public readonly Friend Friend;

        public AddFriendMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split(',');
                Friend = new Friend(
                    strArray[0],
                    int.Parse(strArray[1]),
                    (ActivityStatus)Convert.ToInt32(strArray[2][0]),
                    GetBoolValue(Convert.ToByte(strArray[3][0]))
                );
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
