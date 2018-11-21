using System;
using System.Collections.Generic;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PetsChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> Pets = new Dictionary<int, int>();

        public PetsChosenMessage(byte[] data) : base(data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(BytesToString(data, 1));
                var index = 0;
                while (index < bytes.Length)
                {
                    Pets.Add(Convert.ToInt32(bytes[index]) - 1, Convert.ToInt32(bytes[index + 1]) - 1);
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
