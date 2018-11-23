using RestSharp;
using System;

namespace call_app.Services
{
    public class Rest
    {
        private const string BaseUrl = "https://nr59y0tklh.execute-api.eu-west-1.amazonaws.com/dev";

        public static T Send<T>(RestRequest request) where T : new()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(BaseUrl)
            };
            Console.WriteLine("### Request: " + request);
            var response = client.Execute<T>(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("### Response: " + response.Data);
                return response.Data;
            }
            else
            {
                Console.WriteLine("### HTTP Error!");
                return new T();
            }
        }

    }
}
