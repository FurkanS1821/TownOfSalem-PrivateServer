namespace TownOfSalem_Networking.Client.Home
{
    public class RequestCauldronStatusMessage : BaseMessage
    {
        public RequestCauldronStatusMessage()
            : base(MessageType.RequestCauldronStatus)
        {
        }
    }
}
