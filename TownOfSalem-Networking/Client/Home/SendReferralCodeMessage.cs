namespace TownOfSalem_Networking.Client.Home
{
    public class SendReferralCodeMessage : BaseMessage
    {
        public string Message;
        public SendReferralCodeMessage(byte[] data) : base(data)
        {
            Message = BytesToString(data, 1);
        }
    }
}
