using System;

namespace TownOfSalem_Networking.Server
{
    public class FriendUpdateMessage : BaseMessage
    {
        public readonly int AccountID;
        public readonly ActivityStatus Status;
        public readonly bool OwnsCoven;

        public FriendUpdateMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                int.TryParse(strArray[0], out AccountID);
                Status = (ActivityStatus)strArray[1][0];
                OwnsCoven = GetBoolValue(Convert.ToByte(strArray[2][0]));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
