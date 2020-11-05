using System;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Client.Home
{
    public class AccountSettingMessage : BaseMessage
    {
        public UserSettings.Type SettingType;
        public dynamic SettingValue;
        public Type ValueType;

        public AccountSettingMessage(byte[] data) : base(data)
        {
            try
            {
                SettingType = (UserSettings.Type)(data[1] - 1);
                switch (SettingType)
                {
                    case UserSettings.Type.DisplaySteamPromoPopup:
                    case UserSettings.Type.BugReportingEnabled:
                    case UserSettings.Type.PlayerNumbersEnabled:
                    case UserSettings.Type.VSyncEnabled:
                    case UserSettings.Type.ToasterEnabled:
                    case UserSettings.Type.AutoexpandEnabled:
                    case UserSettings.Type.PlayerLogEnabled:
                    case UserSettings.Type.SoftKeyboardUIResizingEnabled:
                    case UserSettings.Type.ChatFilterEnabled:
                    case UserSettings.Type.MusicMuted:
                    case UserSettings.Type.SoundEffectsMuted:
                    case UserSettings.Type.HideCustomizationsEnabled:
                    case UserSettings.Type.ClassicSkinsOnlyEnabled:
                    case UserSettings.Type.HidePetsEnabled:
                    case UserSettings.Type.EnvironmentalEFfectsEnabled:
                    case UserSettings.Type.ExtendedPlayerNumbersEnabled:
                    case UserSettings.Type.SendChatOnLostFocusEnabled:
                        SettingValue = Convert.ToBoolean(data[2] - 1);
                        ValueType = typeof(bool);
                        break;
                    case UserSettings.Type.QueueLanguage:
                    case UserSettings.Type.UILanguage:
                    case UserSettings.Type.TutorialBehavior:
                    case UserSettings.Type.AntiAliasing:
                        SettingValue = data[2] - 1;
                        ValueType = typeof(int);
                        break;
                    case UserSettings.Type.SoundEffectsVolume:
                    case UserSettings.Type.MusicVolume:
                        SettingValue = (data[2] - 1) / 100f;
                        ValueType = typeof(float);
                        break;
                }
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}