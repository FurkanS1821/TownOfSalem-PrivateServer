using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class PirateDuelOutcomeMessage : BaseMessage
    {
        public readonly PirateDuelAttack Attack;
        public readonly PirateDuelDefense Defense;

        public PirateDuelOutcomeMessage(PirateDuelAttack attack, PirateDuelDefense defense)
            : base(MessageType.PirateDuelOutcome)
        {
            Attack = attack;
            Defense = defense;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Attack);
            writer.Write((byte)Defense);
        }
    }
}
