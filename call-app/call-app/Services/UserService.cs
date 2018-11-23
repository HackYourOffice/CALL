using call_app.Models;
using RestSharp;

namespace call_app.Services
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
            return Rest.Send<User>(request);
        }
    }
}
