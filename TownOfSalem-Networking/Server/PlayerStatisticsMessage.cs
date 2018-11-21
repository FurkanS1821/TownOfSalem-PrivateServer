using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PlayerStatisticsMessage : BaseMessage
    {
        public readonly List<int> Stats = new List<int>();

        public PlayerStatisticsMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                var chArray = new char[1] {','};
                foreach (var s in str.Split(chArray)) Stats.Add(int.Parse(s));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
