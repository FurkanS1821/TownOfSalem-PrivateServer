using System;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Client.Home
{
    public class AccountSettingMessage : BaseMessage
    {
        public UserSettings.Type SettingType;
        public byte SettingValue;

        public AccountSettingMessage(byte[] data) : base(data)
        {
            try
            {
                SettingType = (UserSettings.Type)(data[1] - 1);
                SettingValue = (byte)(data[2] - 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
