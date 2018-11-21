using System;
using System.Collections.Generic;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class HousesChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> Houses = new Dictionary<int, int>();

        public HousesChosenMessage(byte[] data) : base(data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(BytesToString(data, 1));
                var index = 0;
                while (index < bytes.Length)
                {
                    Houses.Add(Convert.ToInt32(bytes[index]) - 1, Convert.ToInt32(bytes[index + 1]) - 1);
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
