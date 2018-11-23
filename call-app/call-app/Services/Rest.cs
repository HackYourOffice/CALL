using RestSharp;
using System;

namespace call_app.Services
{
    class Rest
    {
        private const string BaseUrl = "https://nr59y0tklh.execute-api.eu-west-1.amazonaws.com/dev";

        public static T Send<T>(RestRequest request) where T : new()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(BaseUrl)
            };
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine("### Response Content: " + response.Content);
                return response.Data;
            }
            else
            {
                Console.WriteLine("### HTTP Error: " + response.Content);
                return new T();
            }
        }

        public static bool Send(RestRequest request)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(BaseUrl)
            };
            var response = client.Execute(request);
            return (response.IsSuccessful);
        }

    }
}
