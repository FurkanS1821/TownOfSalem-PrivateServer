namespace TownOfSalem_Networking.Server
{
    public class NameChangeRequiredMessage : BaseMessage
    {
        public readonly bool NameChangeRequired;

        public NameChangeRequiredMessage(byte[] data) : base(data)
        {
            NameChangeRequired = (data[1] & 1) > 0;
        }
    }
}
