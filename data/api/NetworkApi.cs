using FreeWPF.data.api.model;
using Hanssens.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace FreeWPF.data.api
{
    internal class NetworkApi
    {
        private readonly HttpClient httpClient = new HttpClient();

        public AuthResponse auth(AuthBody body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/Authorization");

            request.Content = JsonContent.Create(body);

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AuthResponse>(json);

            var localStorage = new LocalStorage();

            
            localStorage.Store("token", result.Access_token);

            return result;
        }

        public AuthResponse? reag(RegistrationBody body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/Registration");

            request.Content = JsonContent.Create(body);

            var response = httpClient.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                return auth(new AuthBody
                {
                    FirstName = body.FirstName,
                    LastName = body.LastName,
                    Password = body.Password
                });
            }

            return null;
        }

        public User getUser()
        {
            var localstorage = new LocalStorage();
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFuIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQmFzZVVzZXIiLCJJZCI6IjEiLCJuYmYiOjE2ODM5MjI0MzMsImV4cCI6MTY4NTEzMjAzMywiaXNzIjoiRGlwbG9tQXBpIiwiYXVkIjoiRGlwbG9tQ2xpZW50In0.yguGqoub4dkMkUHStMkf3lgcgJ2T0g8BHyK62aZnyGE";

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/api/User");

            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<User>(json);
        }

        public List<Specialization> getSpecializations()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/api/Specialization");

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Specialization>>(json);
        }

        public int updateBalance(int houre)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:5000/api/User/Balance?hours=" + houre.ToString()); 

            var response = httpClient.SendAsync(request).Result;

            return int.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}
