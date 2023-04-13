using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using HTTPClient.DataModels;
using HTTPClient.Helpers;
using Newtonsoft.Json;

namespace HTTPClient.Tests
{
    public class BaseTest
    {
        public static HttpClient httpClient { get; set; }

        //public static HttpResponseMessage bookingDetails { get; set; }



        [TestInitialize]
        public async Task Initialize()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Authenticate
            var createTokenResponse = await AuthenticationHelper.AddToken(httpClient);
            var createTokenResponseData = JsonConvert.DeserializeObject<TokenJsonModel>(createTokenResponse.Content.ReadAsStringAsync().Result);
            if (httpClient.DefaultRequestHeaders.Contains("Cookie"))
                httpClient.DefaultRequestHeaders.Remove("Cookie");
            httpClient.DefaultRequestHeaders.Add("Cookie", $"token={createTokenResponseData}");

        }

        [TestCleanup]
        public void CleanUp()
        {

        }

    }
}
