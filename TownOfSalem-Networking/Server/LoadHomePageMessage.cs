namespace TownOfSalem_Networking.Server
{
    public class LoadHomePageMessage : BaseMessage
    {
        public readonly bool RequiresRegistration;

        public LoadHomePageMessage(byte[] data) : base(data)
        {
            if (data.Length > 1)
            {
                RequiresRegistration = !GetBoolValue(data[1]);
            }
            else
            {
                RequiresRegistration = false;
            }
        }
    }
}
