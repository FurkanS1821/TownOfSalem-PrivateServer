using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PsychicNightAbilityMessage : BaseMessage
    {
        public readonly int Type;
        public readonly List<int> Positions;

        public PsychicNightAbilityMessage(byte[] data) : base(data)
        {
            try
            {
                Type = data[1];
                Positions = new List<int>(data.Length - 2);
                for (var i = 2; i < data.Length; ++i)
                {
                    Positions.Add(data[i] - 1);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
