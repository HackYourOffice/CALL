using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Models
{
    public class EventList
    {
        public string Message { get; set; }
        public List<Event> Events { get; set; }

        public override string ToString()
        {
            return string.Format(
                "EventList(message={0}, events={1})",
                Message, Events.ToString());
        }
    }
}
