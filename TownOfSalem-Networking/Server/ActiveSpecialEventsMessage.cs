using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class ActiveSpecialEventsMessage : BaseMessage
    {
        public List<SpecialEvent> SpecialEvents = new List<SpecialEvent>();

        public ActiveSpecialEventsMessage(byte[] data) : base(data)
        {
            try
            {
                SpecialEvents.Clear();
                var str1 = BytesToString(data, 1);
                var chArray1 = new[] {'*'};
                foreach (var str2 in str1.Split(chArray1))
                {
                    var chArray2 = new[] {','};
                    var strArray = str2.Split(chArray2);
                    if (strArray.Length == 4)
                    {
                        SpecialEvents.Add(new SpecialEvent(
                            int.Parse(strArray[0]),
                            strArray[1],
                            int.Parse(strArray[2]),
                            int.Parse(strArray[3])
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
