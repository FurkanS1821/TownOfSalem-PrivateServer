using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class EarnedAchievementsMessage : BaseMessage
    {
        public List<int> Achievements = new List<int>();

        public EarnedAchievementsMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                var chArray = new char[1] {','};
                foreach (var s in str.Split(chArray)) Achievements.Add(int.Parse(s));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
