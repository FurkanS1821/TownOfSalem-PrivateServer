using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class NameChangeRequiredMessage : BaseMessage
    {
        public readonly bool NameChangeRequired;

        public NameChangeRequiredMessage(bool nameChangeRequired) : base(MessageType.NameChangeRequired)
        {
            NameChangeRequired = nameChangeRequired;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(NameChangeRequired ? 1 : 2));
        }
    }
}