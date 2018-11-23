using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Models
{
    public class CreateEvent
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateEvent() { }

        public CreateEvent(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format(
                "CreateEvent(userid={0}, title={1}, description={2})", 
                UserId, Title, Description);
        }
    }
}
