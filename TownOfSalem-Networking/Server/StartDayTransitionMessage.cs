using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class StartDayTransitionMessage : BaseMessage
    {
        public readonly List<int> DeadPositions = new List<int>();

        public StartDayTransitionMessage(byte[] data) : base(data)
        {
            try
            {
                for (var i = 1; i < data.Length; ++i)
                {
                    DeadPositions.Add(data[i] - 1);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
