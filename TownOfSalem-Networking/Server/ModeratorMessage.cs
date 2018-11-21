using System;

namespace TownOfSalem_Networking.Server
{
    public class ModeratorMessage : BaseMessage
    {
        public readonly ModeratorMessageInfo MessageInfo;

        public ModeratorMessage(byte[] data) : base(data)
        {
            MessageInfo = new ModeratorMessageInfo();
            try
            {
                MessageInfo.MessageId = data[1];
                if (MessageInfo.MessageId == 6 || MessageInfo.MessageId == 7)
                {
                    MessageInfo.Username = BytesToString(data, 2);
                }

                if (MessageInfo.MessageId == 5 || MessageInfo.MessageId == 8 || MessageInfo.MessageId == 9
                    || MessageInfo.MessageId == 36)
                {
                    MessageInfo.Message = BytesToString(data, 2);
                }

                if (MessageInfo.MessageId == 10)
                {
                    var strArray = BytesToString(data, 2).Split(',');
                    MessageInfo.Username = strArray[0];
                    MessageInfo.AccountId = int.Parse(strArray[1]);
                    MessageInfo.TownPoints = int.Parse(strArray[2]);
                    MessageInfo.Elo = int.Parse(strArray[3]);
                    MessageInfo.Suspensions = int.Parse(strArray[4]);
                    MessageInfo.UserLevel = int.Parse(strArray[5]);
                    MessageInfo.SteamId = int.Parse(strArray[6]);
                }

                if (MessageInfo.MessageId == 13)
                {
                    MessageInfo.IsDeveloperModeOnly = GetBoolValue(Convert.ToByte(data[2]));
                }

                if (MessageInfo.MessageId == 24)
                {
                    MessageInfo.IsSuccess = GetBoolValue(Convert.ToByte(data[2]));
                }

                if (MessageInfo.MessageId != 28 && MessageInfo.MessageId != 29 && MessageInfo.MessageId != 30)
                {
                    return;
                }

                MessageInfo.IsOn = GetBoolValue(Convert.ToByte(data[2]));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
