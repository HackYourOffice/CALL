using call_app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.Events
{
    class EventsResponse
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
