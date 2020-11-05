using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PossibleRolesMessage : BaseMessage
    {
        public int TargetIndex;
        public int ScrollIndex;

        public PossibleRolesMessage(byte[] data) : base(data)
        {
            try
            {
                TargetIndex = data[1] - 1;
                ScrollIndex = data[2] - 1;
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}