using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class OtherVampiresMessage : BaseMessage
    {
        public readonly List<VampireInfo> Vampires = new List<VampireInfo>();

        public OtherVampiresMessage(List<VampireInfo> vampires) : base(MessageType.OtherVampires)
        {
            Vampires = vampires;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var vampire in Vampires)
            {
                writer.Write((byte)(vampire.Position + 1));
                writer.Write((byte)(vampire.IsYoungest ? 2 : 0));
            }
        }
    }
}
