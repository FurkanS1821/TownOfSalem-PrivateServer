using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TellLastWillMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly string WillText;
        public readonly bool CoveredInBlood;

        public TellLastWillMessage(int position, bool hasLastWill, string willText, bool coveredInBlood)
            : base(MessageType.TellLastWill)
        {
            Position = position;
            HasLastWill = hasLastWill;
            WillText = willText;
            CoveredInBlood = coveredInBlood;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            if (!HasLastWill)
            {
                if (CoveredInBlood)
                {
                    writer.Write((byte)3);
                }
                else
                {
                    writer.Write((byte)1);
                }

                return;
            }

            writer.Write((byte)2);
            writer.Write(Encoding.UTF8.GetBytes(WillText));
        }
    }
}