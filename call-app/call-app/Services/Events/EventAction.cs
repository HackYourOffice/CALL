using call_app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.Events
{
    class EventAction
    {
        public string EventId { get; set; }
        public int ActionCode { get; set; }

        public EventAction(string eventId, ActionCode actionCode)
        {
            EventId = eventId;
            ActionCode = (int)actionCode;
        }
    }
}
