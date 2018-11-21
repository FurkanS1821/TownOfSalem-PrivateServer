namespace TownOfSalem_Networking.Client.Global
{
    public class ReturnHomeMessage : BaseMessage
    {
        public ReturnHomeMessage()
            : base(MessageType.ReturnHome)
        {
        }
    }
}
