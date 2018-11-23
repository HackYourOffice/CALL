using call_app.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services
{
    public class EventService
    {
        public CreateEvent Create(CreateEvent createEvent)
        {
            createEvent.UserId = Share.User.UserId;
            var request = new RestRequest
            {
                Resource = "create-event",
                Method = Method.POST,
            };
            request.AddJsonBody(createEvent);
            return Rest.Send<CreateEvent>(request);
        }

    }
}
