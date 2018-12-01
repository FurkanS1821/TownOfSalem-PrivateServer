using System.Collections.Generic;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class ActiveSpecialEventsMessage : BaseMessage
    {
        public List<SpecialEvent> SpecialEvents;

        public ActiveSpecialEventsMessage(List<SpecialEvent> specialEvents) : base(MessageType.ActiveSpecialEvents)
        {
            SpecialEvents = specialEvents;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < SpecialEvents.Count; i++)
            {
                var specialEvent = SpecialEvents[i];

                writer.Write(Encoding.UTF8.GetBytes(specialEvent.Type.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(specialEvent.Data));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(specialEvent.StartTime.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(specialEvent.EndTime.ToString()));

                if (i < SpecialEvents.Count - 1)
                {
                    writer.Write('*');
                }
            }
        }
    }
}
