using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Models
{
    public class CreatedEvent
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
