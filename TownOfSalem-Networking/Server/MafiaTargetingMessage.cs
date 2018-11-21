using System;

namespace TownOfSalem_Networking.Server
{
    public class MafiaTargetingMessage : BaseMessage
    {
        public readonly FactionTargetInfo TargetInfo;

        public MafiaTargetingMessage(byte[] data) : base(data)
        {
            try
            {
                TargetInfo = new FactionTargetInfo
                {
                    Position = data[1] - 1,
                    Role = data[2] - 1,
                    Target = data[3] - 1,
                    TargetBehavior = data[4]
                };

                if (data.Length > 5)
                {
                    TargetInfo.Info = data[5];
                }

                if (data.Length > 6)
                {
                    TargetInfo.AdditionalInfo = data[6];
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
