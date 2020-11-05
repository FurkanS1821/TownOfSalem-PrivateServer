using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class CaptchaQuestion : BaseMessage
    {
        public readonly string Question;

        public CaptchaQuestion(string question) : base(MessageType.CaptchaQuestion)
        {
            Question = question;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Question));
        }
    }
}