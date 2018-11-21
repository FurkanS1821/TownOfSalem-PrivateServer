using System;
using System.Collections.Generic;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ActiveGameModesMessage : BaseMessage
    {
        public List<int> ActiveModes = new List<int>();

        public ActiveGameModesMessage(byte[] data) : base(data)
        {
            try
            {
                foreach (var num in Encoding.ASCII.GetBytes(BytesToString(data, 1)))
                {
                    ActiveModes.Add(Convert.ToInt32(num));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
