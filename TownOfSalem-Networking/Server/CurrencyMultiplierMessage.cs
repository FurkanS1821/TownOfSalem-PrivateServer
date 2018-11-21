using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class CurrencyMultiplierMessage : BaseMessage
    {
        public readonly float TownPoints;
        public readonly float MeritPoints;

        public CurrencyMultiplierMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                var dictionary = new Dictionary<int, int> {{1, 1}, {3, 1}};
                foreach (var str1 in strArray)
                {
                    var str2 = str1.Substring(0, 1);
                    var str3 = str1.Substring(1, 1);
                    var int32_1 = Convert.ToInt32(str2);
                    var int32_2 = Convert.ToInt32(str3);
                    if (dictionary.ContainsKey(int32_1))
                    {
                        dictionary[int32_1] = int32_2;
                    }
                }

                TownPoints = float.Parse(dictionary[1].ToString());
                MeritPoints = float.Parse(dictionary[3].ToString());
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
