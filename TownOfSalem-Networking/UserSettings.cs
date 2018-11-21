namespace TownOfSalem_Networking
{
    public class UserSettings
    {
        public static string UserSettingKeyPrefix = "UserSetting.";
        public float SoundEffectsVolume = 0.5f;
        public float MusicVolume = 0.5f;
        public bool ChatFilterEnabled;
        public bool MusicMuted;
        public bool SoundEffectsMuted;
        public bool HideCustomizationsEnabled;
        public bool ClassicSkinsOnlyEnabled;
        public bool HidePetsEnabled;
        public int QueueLanguage;
        public int UILanguage;
        public int TutorialBehavior;

        public enum Type
        {
            ChatFilterEnabled,
            SoundEffectsMuted,
            MusicMuted,
            HideCustomizationsEnabled,
            ClassicSkinsOnlyEnabled,
            HidePetsEnabled,
            DisplaySteamPopup,
            SoundEffectsVolume,
            MusicVolume,
            QueueLanguage,
            UILanguage,
            TutorialBehavior,
        }
    }
}
