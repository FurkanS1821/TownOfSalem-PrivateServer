﻿using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class SendReferralCodeMessage : BaseMessage
    {
        public string Message;

        public SendReferralCodeMessage(byte[] data) : base(data)
        {
            try
            {
                Message = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}