using System;

namespace TownOfSalem_Networking.Server
{
    public class ConfirmFriendRequestMessage : BaseMessage
    {
        public readonly int AccountID;
        public readonly ActivityStatus Status;
        public readonly bool Success;
        public readonly bool OwnsCoven;

        public ConfirmFriendRequestMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                int.TryParse(strArray[0], out AccountID);
                if (strArray.Length < 3)
                {
                    Success = false;
                    Status = ActivityStatus.Offline;
                    OwnsCoven = false;
                }
                else
                {
                    Success = true;
                    Status = (ActivityStatus)strArray[1][0];
                    OwnsCoven = GetBoolValue(Convert.ToByte(strArray[2][0]));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
