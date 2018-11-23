using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.Services.Users
{
    class UserResponse
    {
        public string Message { get; set; }
        public string UserId { get; set; }

        public UserResponse() { }

        public override string ToString()
        {
            return string.Format("UserResponse(message={0}, userid={1})", Message, UserId);
        }
    }
}
