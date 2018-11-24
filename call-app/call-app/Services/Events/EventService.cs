using call_app.Models;
using call_app.Services.Events;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services
{
    public class EventService
    {
        public Event Create(CreateEvent createEvent)
        {
            createEvent.UserId = Share.User.UserId;
            var request = new RestRequest
            {
                Resource = "create-event",
                Method = Method.POST
            };
            request.AddJsonBody(createEvent);
            return Rest.Send<EventResponse>(request).Event;
        }

        public List<Event> Get()
        {
            var request = new RestRequest
            {
                Resource = "list-events",
                Method = Method.POST
            };
            return Rest.Send<EventsResponse>(request).Events;
        }

        public List<Event> GetOwn()
        {
            var request = new RestRequest
            {
                Resource = "list-events",
                Method = Method.POST
            };
            request.AddJsonBody(Share.User);
            return Rest.Send<EventsResponse>(request).Events;
        }

        public bool RegisterAt(Event eventToRegisterAt)
        {
            var request = new RestRequest
            {
                Resource = "subscribe",
                Method = Method.POST
            };
            request.AddJsonBody(new Subscription(Share.User.UserId, eventToRegisterAt.EventId));
            return Rest.Send(request);
        }

        public bool NotifySubscriberOf(Event subscribedEvent, ActionCode actionCode = ActionCode.NOTIFICATION)
        {
            var request = new RestRequest
            {
                Resource = "notify",
                Method = Method.POST
            };
            request.AddJsonBody(new EventAction(subscribedEvent.EventId, actionCode));
            return Rest.Send(request);
        }

        public List<Event> Poll()
        {
            var request = new RestRequest
            {
                Resource = "poll",
                Method = Method.POST
            };
            request.AddJsonBody(Share.User);
            return Rest.Send<EventsResponse>(request).Events;
        }

		public EventSubscriber NumberOfSubscribers(Event theEvent) 
		{
			var request = new RestRequest
            {
                Resource = "count",
                Method = Method.POST
            };
			request.AddJsonBody(new EventIdentifier(theEvent.EventId));
			return Rest.Send<EventSubscriber>(request);
		}

		public bool Accept(Event theEvent)
        {
            var request = new RestRequest
            {
                Resource = "accept-event",
                Method = Method.POST
            };
			request.AddJsonBody(new EventIdentifier(theEvent.EventId));
			return Rest.Send(request);
        }

        public Event GetById(string eventId)
        {
			var request = new RestRequest
            {
                Resource = "get-event-by-event-id",
                Method = Method.POST
            };
			request.AddJsonBody(new EventIdentifier(eventId));
			return Rest.Send<Event>(request);
        }


		class EventIdentifier 
		{
			public string EventId { get; set; }
			public EventIdentifier(string id)
			{
				EventId = id;
			}
		} 
    }
}
