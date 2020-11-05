namespace TownOfSalem_Networking.Structs
{
    public class UserSettings
    {
        public static string USER_SETTING_KEY_PREFIX = "UserSetting.";
        public bool DisplaySteamPromoPopup = true;
        public float SoundEffectsVolume = 0.5f;
        public float MusicVolume = 0.5f;
        public bool BugReportingEnabled = true;
        public bool PlayerNumbersEnabled = true;
        public bool VSyncEnabled = true;
        public bool ToasterEnabled = true;
        public bool AutoexpandEnabled = true;
        public bool PlayerLogEnabled = true;
        public bool SoftKeyboardUIResizingEnabled = true;
        public bool ChatFilterEnabled;
        public bool MusicMuted;
        public bool SoundEffectsMuted;
        public bool HideCustomizationsEnabled;
        public bool ClassicSkinsOnlyEnabled;
        public bool HidePetsEnabled;
        public int QueueLanguage;
        public int UILanguage;
        public int TutorialBehavior;
        public bool EnvironmentalEffectsEnabled;
        public int AntiAliasing;
        public bool ExtendedPlayerNumbersEnabled;
        public bool SendChatOnLostFocusEnabled;

        public enum Type
        {
            ChatFilterEnabled,
            SoundEffectsMuted,
            MusicMuted,
            HideCustomizationsEnabled,
            ClassicSkinsOnlyEnabled,
            HidePetsEnabled,
            DisplaySteamPromoPopup,
            SoundEffectsVolume,
            MusicVolume,
            QueueLanguage,
            UILanguage,
            TutorialBehavior,
            EnvironmentalEFfectsEnabled,
            BugReportingEnabled,
            PlayerNumbersEnabled,
            VSyncEnabled,
            AntiAliasing,
            ToasterEnabled,
            ExtendedPlayerNumbersEnabled,
            AutoexpandEnabled,
            PlayerLogEnabled,
            SoftKeyboardUIResizingEnabled,
            SendChatOnLostFocusEnabled,
        }
    }
}
