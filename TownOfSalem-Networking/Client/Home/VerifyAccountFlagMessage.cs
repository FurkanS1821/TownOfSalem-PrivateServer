namespace TownOfSalem_Networking.Client.Home
{
    public class VerifyAccountFlagMessage : BaseMessage
    {
        public int Flag;

        public VerifyAccountFlagMessage(byte[] data) : base(data)
        {
            Flag = data[1];
        }
    }
}
