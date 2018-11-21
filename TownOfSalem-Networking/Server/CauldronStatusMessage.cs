using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class CauldronStatusMessage : BaseMessage
    {
        public readonly List<int> AvailablePotions = new List<int>();
        public readonly List<ProductItem> Awards = new List<ProductItem>();
        public readonly int CauldronType;
        public readonly int Progress;
        public readonly int ProgressTarget;
        public readonly bool IsCompleted;
        public readonly int CooldownSeconds;

        public CauldronStatusMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray1 = BytesToString(data, 1).Split(',');
                CauldronType = int.Parse(strArray1[0]);
                Progress = int.Parse(strArray1[1]);
                ProgressTarget = int.Parse(strArray1[2]);
                IsCompleted = Convert.ToBoolean(byte.Parse(strArray1[3]));
                CooldownSeconds = int.Parse(strArray1[4]);
                if (strArray1[5].Length > 0)
                {
                    var str = strArray1[5];
                    foreach (var s in str.Split('*'))
                    {
                        AvailablePotions.Add(int.Parse(s));
                    }
                }

                if (strArray1[6].Length <= 0)
                {
                    return;
                }

                var str1 = strArray1[6];
                foreach (var str2 in str1.Split('*'))
                {
                    var chArray2 = new[] {'|'};
                    var strArray2 = str2.Split(chArray2);
                    if (int.Parse(strArray2[0]) != 5)
                    {
                        Awards.Add(new ProductItem(
                            int.Parse(strArray2[0]),
                            int.Parse(strArray2[1]),
                            int.Parse(strArray2[2])
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
