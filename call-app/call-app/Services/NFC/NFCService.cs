using call_app.Models;
using call_app.Services.Events;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.NFC
{
    public class NFCService
    {
        public bool Bind(string nfcId, Event nfcEvent)
        {
            var request = new RestRequest
            {
                Resource = "register-nfc",
                Method = Method.POST,
            };
            request.AddJsonBody(new NFCEventBind(nfcId, nfcEvent.EventId));
            return Rest.Send(request);
        }

        public Event GetEvent(string nfcId)
        {
            var request = new RestRequest
            {
                Resource = "get-event-by-nfc",
                Method = Method.POST,
            };
            request.AddJsonBody(new NfcIdentifier(nfcId));
            return Rest.Send<EventResponse>(request).Event;
        }
    }
   
}
