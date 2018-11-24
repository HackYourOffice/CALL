using System;
namespace call_app.Services.Events
{
    public class EventSubscriber
    {
		public string Message { get; set; }
		public int TotalSubscribers { get; set; }
		public int TotalAccepted { get; set; }

        public EventSubscriber()
        {
        }
    }
}
