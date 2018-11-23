using call_app.Models;
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
                Method = Method.POST,
            };
            request.AddJsonBody(createEvent);
            return Rest.Send<CreatedEvent>(request).Event;
        }

        public List<Event> Get()
        {
            var request = new RestRequest
            {
                Resource = "list-events",
                Method = Method.POST,
            };
            return Rest.Send<EventList>(request).Events;
        }

        public List<Event> GetOwn()
        {
            var request = new RestRequest
            {
                Resource = "list-events",
                Method = Method.POST,
            };
            request.AddJsonBody(Share.User);
            return Rest.Send<EventList>(request).Events;
        }

        public bool RegisterAt(Event eventToRegisterAt)
        {
            var request = new RestRequest
            {
                Resource = "subscribe",
                Method = Method.POST,
            };
            request.AddJsonBody(new Subscription(Share.User.UserId, eventToRegisterAt.EventId));
            return Rest.Send(request);
        }

        public bool NotifySubscriberOf(Event subscribedEvent, ActionCode actionCode = ActionCode.NOTIFICATION)
        {
            var request = new RestRequest
            {
                Resource = "notify",
                Method = Method.POST,
            };
            request.AddJsonBody(new EventAction(subscribedEvent.EventId, actionCode));
            return Rest.Send(request);
        }

        public List<Event> Poll()
        {
            var request = new RestRequest
            {
                Resource = "poll",
                Method = Method.POST,
            };
            request.AddJsonBody(Share.User);
            return Rest.Send<EventList>(request).Events;
        }
    }//EventService

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

    class EventAction
    {
        public string EventId { get; set; }
        public int ActionCode { get; set; }

        public EventAction(string eventId, ActionCode actionCode)
        {
            EventId = eventId;
            ActionCode = (int) actionCode;
        }
    }

}
