using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Models
{
    public class User
    {
        public string UserId { get; set; }

        public User() { }

        public override string ToString()
        {
            return string.Format("User(userid={0})", UserId);
        }
    }
}
