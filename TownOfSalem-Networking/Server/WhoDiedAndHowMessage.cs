using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class WhoDiedAndHowMessage : BaseMessage
    {
        public readonly List<int> How = new List<int>();
        public readonly int Position;
        public readonly int Role;
        public readonly bool WasLynched;

        public WhoDiedAndHowMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                Role = Convert.ToInt32(data[2]) - 1;
                WasLynched = GetBoolValue(Convert.ToByte(data[3]));
                for (var index = 4; index < data.Length; ++index) How.Add(data[index]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
