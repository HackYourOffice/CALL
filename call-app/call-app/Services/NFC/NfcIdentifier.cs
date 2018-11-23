using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.NFC
{
    class NfcIdentifier
    {
        public string NfcId { get; set; }

        public NfcIdentifier(string nfcId)
        {
            NfcId = nfcId;
        }
    }
}
