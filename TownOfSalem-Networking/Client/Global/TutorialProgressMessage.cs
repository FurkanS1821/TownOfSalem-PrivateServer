using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Client.Global
{
    public class TutorialProgressMessage : BaseMessage
    {
        public List<int> Tips;

        public TutorialProgressMessage(byte[] data) : base(data)
        {
            try
            {
                Tips = new List<int>();
                var lines = BytesToString(data, 1).Split('*');
                foreach (var line in lines)
                {
                    Tips.Add(Convert.ToInt32(line));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
