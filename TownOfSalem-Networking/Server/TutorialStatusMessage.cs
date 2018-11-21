using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class TutorialStatusMessage : BaseMessage
    {
        public List<int> TutorialStatus = new List<int>();

        public TutorialStatusMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                foreach (var s in str.Split(','))
                {
                    TutorialStatus.Add(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
