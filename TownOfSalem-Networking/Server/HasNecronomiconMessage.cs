using System;

namespace TownOfSalem_Networking.Server
{
    public class HasNecronomiconMessage : BaseMessage
    {
        public readonly bool HasNecronomicon;
        public readonly int NightsUntilNecronomicon;

        public HasNecronomiconMessage(byte[] data) : base(data)
        {
            try
            {
                if (data[1] == 1)
                {
                    HasNecronomicon = true;
                }
                else
                {
                    if (data[1] != 2)
                    {
                        return;
                    }

                    HasNecronomicon = false;
                    NightsUntilNecronomicon = data[2];
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
