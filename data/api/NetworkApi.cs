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

            localStorage.Store("token", result);
            localStorage.Dispose();

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
            
            var token = localstorage.Get<AuthResponse>("token").Access_token;

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
            var localstorage = new LocalStorage();

            var token = localstorage.Get<AuthResponse>("token").Access_token;

            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:5000/api/User/Balance?hours=" + houre.ToString());

            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;

            return int.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}
