namespace TownOfSalem_Networking.Server
{
    public class SuccessfulAccountCreationOrLinkingMessage : BaseMessage
    {
        public SuccessfulAccountCreationOrLinkingMessage() : base(MessageType.SuccessfulAccountCreationOrLinking)
        {
        }
    }
}