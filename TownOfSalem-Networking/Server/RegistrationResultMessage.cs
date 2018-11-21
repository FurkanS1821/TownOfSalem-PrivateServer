using System;

namespace TownOfSalem_Networking.Server
{
    public class RegistrationResultMessage : BaseMessage
    {
        public readonly RegistrationStatus Status = RegistrationStatus.Failed;

        public RegistrationResultMessage(byte[] data) : base(data)
        {
            try
            {
                Status = (RegistrationStatus)(data[1] - 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
