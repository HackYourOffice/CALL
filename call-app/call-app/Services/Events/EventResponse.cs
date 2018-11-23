using call_app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.Events
{
    class EventResponse
    {
        public string Message { get; set; }
        public Event Event { get; set; }

        public override string ToString()
        {
            return string.Format(
                "CreateEvent(message={0}, event={1})",
                Message, Event);
        }

    }
}
