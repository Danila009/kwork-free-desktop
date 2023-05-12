using FreeWPF.data.api.model;
using Hanssens.Net;
using Newtonsoft.Json;
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
    }
}
