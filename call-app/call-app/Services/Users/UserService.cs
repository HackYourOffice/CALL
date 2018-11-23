using call_app.Models;
using RestSharp;

namespace call_app.Services.Users
{
    public class UserService
    {
        public User Create()
        {
            var request = new RestRequest
            {
                Resource = "create-user",
                Method = Method.POST
            };
            request.RequestFormat = DataFormat.Json;
            return new User
            {
                UserId = Rest.Send<UserResponse>(request).UserId
            };
        }
    }
}
