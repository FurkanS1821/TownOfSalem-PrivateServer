using System;

namespace TownOfSalem_Networking.Server
{
    public class SettingsInformationMessage : BaseMessage
    {
        public UserSettings Settings;

        public SettingsInformationMessage(byte[] data) : base(data)
        {
            try
            {
                Settings = new UserSettings
                {
                    ChatFilterEnabled = GetBoolValue(data[1]),
                    MusicMuted = GetBoolValue(data[2]),
                    SoundEffectsMuted = GetBoolValue(data[3]),
                    HideCustomizationsEnabled = !GetBoolValue(data[4]),
                    ClassicSkinsOnlyEnabled = GetBoolValue(data[5]),
                    HidePetsEnabled = !GetBoolValue(data[6]),
                    SoundEffectsVolume = (data[7] - 1) / 100f,
                    MusicVolume = (data[8] - 1) / 100f,
                    QueueLanguage = data[9] - 1,
                    UILanguage = data[10] - 1,
                    TutorialBehavior = data[11] - 1
                };
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
