﻿using System.IO;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class SettingsInformationMessage : BaseMessage
    {
        public UserSettings Settings;

        public SettingsInformationMessage(UserSettings settings) : base(MessageType.SettingsInformation)
        {
            Settings = settings;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Settings.ChatFilterEnabled ? 2 : 1));
            writer.Write((byte)(Settings.MusicMuted ? 2 : 1));
            writer.Write((byte)(Settings.SoundEffectsMuted ? 2 : 1));
            writer.Write((byte)(Settings.HideCustomizationsEnabled ? 1 : 2));
            writer.Write((byte)(Settings.ClassicSkinsOnlyEnabled ? 2 : 1));
            writer.Write((byte)(Settings.HidePetsEnabled ? 1 : 2));
            writer.Write((byte)(Settings.SoundEffectsVolume * 100 + 1));
            writer.Write((byte)(Settings.MusicVolume * 100 + 1));
            writer.Write((byte)(Settings.QueueLanguage + 1));
            writer.Write((byte)(Settings.UILanguage + 1));
            writer.Write((byte)(Settings.TutorialBehavior + 1));
        }
    }
}