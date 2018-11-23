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
            var request = new RestRequest
            {
                Resource = "create-event",
                Method = Method.POST
            };
            request.AddBody(createEvent);
            return Rest.Send<Event>(request);
        }

    }
}
