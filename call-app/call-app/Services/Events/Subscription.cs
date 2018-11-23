using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.Events
{
    class Subscription
    {
        public string UserId { get; set; }
        public string EventId { get; set; }

        public Subscription(string userId, string eventId)
        {
            UserId = userId;
            EventId = eventId;
        }
    }
}
