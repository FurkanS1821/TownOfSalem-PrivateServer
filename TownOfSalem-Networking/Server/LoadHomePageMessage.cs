using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class LoadHomePageMessage : BaseMessage
    {
        public readonly bool RequiresRegistration;

        public LoadHomePageMessage(bool requiresRegistration) : base(MessageType.LoadHomePage)
        {
            RequiresRegistration = requiresRegistration;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RequiresRegistration ? 0 : 2));
        }
    }
}
