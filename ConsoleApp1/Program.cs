using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var returnMessage = APIService.GetAuthorizeToken().Result;
            Console.WriteLine(string.Format("token : ", returnMessage));
        }
    }

    public static class APIService
    {
        public static async Task<string> GetAuthorizeToken()
        {
            // Initialization.  
            string responseObj = string.Empty;
            // Posting.  
            var token = new Token();
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri("http://localhost:29100/");

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Initialization.  
                HttpResponseMessage responseMessage = new HttpResponseMessage();
                List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();
                allIputParams.Add(new KeyValuePair<string, string>("grant_type", "password"));
                allIputParams.Add(new KeyValuePair<string, string>("username", "jignesh"));
                allIputParams.Add(new KeyValuePair<string, string>("password", "user123456"));

                // Convert Request Params to Key Value Pair.  
                // URL Request parameters.  
                HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

                // HTTP POST  
                responseMessage = await client.PostAsync("oauth2/token", requestParams).ConfigureAwait(false);

                // Verification  
                string _json = await responseMessage.Content.ReadAsStringAsync();
                var response = new Token();
                JObject obj = JsonConvert.DeserializeObject<JObject>(_json);
                response = obj.ToObject<Token>();
                token = response;
            }

            using (var client = new HttpClient())
            {
                // Initialization  
                string authorization = token.AccessToken;

                // Setting Authorization.  
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                // Setting Base address.  
                client.BaseAddress = new Uri("http://localhost:29100/");

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage responseMessage = new HttpResponseMessage();

                // HTTP GET  
                responseMessage = await client.GetAsync("api/v1/Item").ConfigureAwait(false);

                // Verification  
                string _json = await responseMessage.Content.ReadAsStringAsync();
                responseObj = _json;
                var response = new AppResponseModel<string>();
                JObject obj = JsonConvert.DeserializeObject<JObject>(_json);
                response = obj.ToObject<AppResponseModel<string>>();
                if (response.IsSuccess)
                {
                    responseObj = response.Data;
                }
            }

            return responseObj;
        }
    }

    public class AppResponseModel<T>
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public string DeveloperMessage { get; set; }
        public T Data { get; set; }
        public bool IsWarning { get; set; } = false;

    }
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
