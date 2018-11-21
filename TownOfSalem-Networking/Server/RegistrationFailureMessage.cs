using System;

namespace TownOfSalem_Networking.Server
{
    public class RegistrationFailureMessage : BaseMessage
    {
        public readonly RegistrationFailure Reason;

        public RegistrationFailureMessage(byte[] data) : base(data)
        {
            try
            {
                Reason = (RegistrationFailure)Convert.ToInt32(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
