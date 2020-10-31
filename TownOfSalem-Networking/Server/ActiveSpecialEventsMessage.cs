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
            var packetContents = new List<string>();
            foreach (var @event in SpecialEvents)
            {
                packetContents.Add($"{@event.Type},{@event.Data},{@event.StartTime},{@event.EndTime}");
            }

            writer.Write(Encoding.UTF8.GetBytes(string.Join("*", packetContents)));
        }
    }
}