using System;

namespace TownOfSalem_Networking.Server
{
    public class VampiresCanConvertMessage : BaseMessage
    {
        public readonly bool CanConvert;

        public VampiresCanConvertMessage(byte[] data) : base(data)
        {
            try
            {
                CanConvert = GetBoolValue(Convert.ToByte(data[1]));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
