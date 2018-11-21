using System;
using System.Collections.Generic;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class DeathAnimationsChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> DeathAnimations = new Dictionary<int, int>();

        public DeathAnimationsChosenMessage(byte[] data) : base(data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(BytesToString(data, 1));
                var index = 0;
                while (index < bytes.Length)
                {
                    DeathAnimations.Add(Convert.ToInt32(bytes[index]) - 1, Convert.ToInt32(bytes[index + 1]) - 1);
                    index += 2;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
