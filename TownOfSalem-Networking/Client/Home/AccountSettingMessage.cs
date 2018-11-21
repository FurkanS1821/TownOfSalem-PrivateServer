using System;
using System.IO;

namespace TownOfSalem_Networking.Client.Home
{
    public class AccountSettingMessage : BaseMessage
    {
        public UserSettings.Type SettingType;
        private byte _settingValue;

        public AccountSettingMessage(UserSettings.Type setting, float value) : base(MessageType.SendAccountSetting)
        {
            SettingType = setting;
            _settingValue = (byte)Math.Floor(value * 100f);
        }

        public AccountSettingMessage(UserSettings.Type setting, int value) : base(MessageType.SendAccountSetting)
        {
            SettingType = setting;
            _settingValue = (byte)value;
        }

        public AccountSettingMessage(UserSettings.Type setting, bool value) : base(MessageType.SendAccountSetting)
        {
            SettingType = setting;
            _settingValue = value ? (byte)1 : (byte)0;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)((byte)SettingType + 1U));
            writer.Write((byte)(_settingValue + 1U));
        }
    }
}
