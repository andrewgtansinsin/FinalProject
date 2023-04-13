using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPClient.Resources;
using HTTPClient.Tests.TestData;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HTTPClient.Helpers
{
    public class AuthenticationHelper
    {
        /// <summary>
        /// Send POST request for Authentication Bearer Token
        /// </summary>
        ///
        public static async Task<HttpResponseMessage> AddToken(HttpClient client)
        {
            // Create data
            var credentials = GenerateCredentials.credentials();
            var authenticationURL = Endpoints.PostToken();

            // Create request
            var request = JsonConvert.SerializeObject(credentials);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Make API call and return response
            return await client.PostAsync(authenticationURL, content);

        }
    }
}
