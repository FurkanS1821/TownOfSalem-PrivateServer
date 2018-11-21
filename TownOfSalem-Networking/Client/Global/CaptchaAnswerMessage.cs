using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class CaptchaAnswerMessage : BaseMessage
    {
        public string Answer;

        public CaptchaAnswerMessage(string answer) : base(MessageType.CaptchaAnswer)
        {
            Answer = answer.Trim();
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Answer));
        }
    }
}
