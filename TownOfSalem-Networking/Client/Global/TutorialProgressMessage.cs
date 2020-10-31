using System;
using System.Collections.Generic;
using System.Linq;

namespace TownOfSalem_Networking.Client.Global
{
    public class TutorialProgressMessage : BaseMessage
    {
        public List<int> Tips;

        public TutorialProgressMessage(byte[] data) : base(data)
        {
            try
            {
                var packet = BytesToString(data, 1).Split('*');
                Tips = packet.Select(x => Convert.ToInt32(x)).ToList();
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}