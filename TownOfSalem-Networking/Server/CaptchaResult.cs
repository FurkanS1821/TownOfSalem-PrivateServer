using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CaptchaResult : BaseMessage
    {
        public readonly bool Status;

        public CaptchaResult(bool status) : base(MessageType.CaptchaResult)
        {
            Status = status;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Status ? 2 : 1));
        }
    }
}