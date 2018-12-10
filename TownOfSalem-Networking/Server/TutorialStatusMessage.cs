using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TutorialStatusMessage : BaseMessage
    {
        public int[] TutorialStatus;

        public TutorialStatusMessage(int[] tutorialStatus) : base(MessageType.TutorialStatus)
        {
            TutorialStatus = tutorialStatus;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < TutorialStatus.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(TutorialStatus[i].ToString()));

                if (i < TutorialStatus.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
