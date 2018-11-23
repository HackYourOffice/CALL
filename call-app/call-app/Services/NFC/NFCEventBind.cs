using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.NFC
{
    class NFCEventBind
    {
        public string Message { get; set; }
        public string NfcId { get; set; }
        public string EventId { get; set; }

        public NFCEventBind() { }

        public NFCEventBind(string nfcId, string eventId)
        {
            NfcId = nfcId;
            EventId = eventId;
        }

        public override string ToString()
        {
            return string.Format(
                "NFCEventBind(message={0}, nfcid={1}, eventid={2})",
                Message, NfcId, EventId);
        }
    }
}
