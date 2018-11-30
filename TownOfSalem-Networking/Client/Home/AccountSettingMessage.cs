using System;

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
                SettingType = (UserSettings.Type)(data[1] - 1u);
                SettingValue = (byte)(data[2] - 1u);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
