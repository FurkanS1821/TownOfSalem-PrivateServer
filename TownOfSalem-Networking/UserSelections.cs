using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking
{
    public class UserSelections : IEquatable<UserSelections>
    {
        public string InGameName = string.Empty;
        public int Character = -1;
        public int Pet = -1;
        public int House = -1;
        public int Background = -1;
        public int DeathAnimation = -1;
        public int LobbyIcon = -1;
        public int[] Scrolls = { -2, -2, -2 };
        public const int NO_PET = -2;
        public const int NO_SCROLL = -2;
        public const int RANDOM_SELECTION = -3;

        public bool Equals(UserSelections other)
        {
            return InGameName.Equals(other.InGameName) && Character == other.Character && Pet == other.Pet &&
                   House == other.House && Background == other.Background && DeathAnimation == other.DeathAnimation
                   && LobbyIcon == other.LobbyIcon && ArraysEqual(Scrolls, other.Scrolls);
        }

        public UserSelections Clone()
        {
            return new UserSelections
            {
                InGameName = InGameName,
                Character = Character,
                Pet = Pet,
                House = House,
                Background = Background,
                DeathAnimation = DeathAnimation,
                LobbyIcon = LobbyIcon,
                Scrolls = (int[])Scrolls.Clone()
            };
        }

        private bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
            {
                return true;
            }

            if (a1 == null || a2 == null || a1.Length != a2.Length)
            {
                return false;
            }

            for (var i = 0; i < a1.Length; ++i)
            {
                if (!EqualityComparer<T>.Default.Equals(a1[i], a2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
