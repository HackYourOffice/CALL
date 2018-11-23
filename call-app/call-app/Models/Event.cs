using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Models
{
    public class Event
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Event() { }

        public override string ToString()
        {
            return string.Format(
                "Event(userid={0}, eventid={1}, title={2}, description={3})", 
                UserId, EventId, Title, Description);
        }
    }
}
