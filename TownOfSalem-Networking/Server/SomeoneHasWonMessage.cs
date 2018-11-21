using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class SomeoneHasWonMessage : BaseMessage
    {
        public readonly List<int> WinningPositions = new List<int>();
        public readonly int WinningFaction;

        public SomeoneHasWonMessage(byte[] data) : base(data)
        {
            try
            {
                WinningFaction = data[1];
                for (var i = 2; i < data.Length; ++i)
                {
                    WinningPositions.Add(data[i] - 1);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
