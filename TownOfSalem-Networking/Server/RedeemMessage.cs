using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class RedeemMessage : BaseMessage
    {
        public readonly RedeemResult Result;
        public readonly int ItemType;
        public readonly int ItemId;
        public readonly List<string> AdditionalValues;

        public RedeemMessage(byte[] data) : base(data)
        {
            try
            {
                Result = (RedeemResult)data[1];
                if (data.Length <= 2)
                {
                    return;
                }

                ItemType = data[2];
                ItemId = int.Parse(BytesToString(data, 3).Split(',')[0]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
