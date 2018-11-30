using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class OtherWitchesMessage : BaseMessage
    {
        public readonly int[] Positions;
        public readonly int[] Roles;

        public OtherWitchesMessage(int[] positions, int[] roles) : base(MessageType.OtherWitches)
        {
            Positions = positions;
            Roles = roles;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Positions.Length; i++)
            {
                writer.Write((byte)(Positions[i] + 1));
                writer.Write((byte)(Roles[i] + 1));
            }
        }
    }
}
