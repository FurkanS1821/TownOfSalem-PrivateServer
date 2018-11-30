namespace TownOfSalem_Networking.Client.Home
{
    public class PartyMessage : BaseMessage
    {
        public string Message;

        public PartyMessage(byte[] data) : base(data)
        {
            Message = BytesToString(data, 1);
        }
    }
}
