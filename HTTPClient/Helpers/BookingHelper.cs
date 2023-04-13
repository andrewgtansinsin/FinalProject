using System.Net.Http;
using HTTPClient.DataModels;
using HTTPClient.Resources;
using HTTPClient.Tests.TestData;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTTPClient.Helpers;
using System.Net;
using Newtonsoft.Json;
using System;

namespace HTTPClient.Helpers
{
    /// <summary>
    /// Class containing all methods for booking
    /// </summary>
    public class BookingHelper
    {

        /// <summary>
        /// Send POST request to add new booking
        /// </summary>
        ///
        public static async Task<HttpResponseMessage> AddNewBooking(HttpClient client)
        {

            //HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            var generateBookingDetails = GenerateBooking.clientBooking();
            //var postRequestEndpoint = Endpoints.PostBooking();

            // Serialize Content
            var request = JsonConvert.SerializeObject(generateBookingDetails);
            //httpRequestMessage.Content = new StringContent(request, Encoding.UTF8, "application/json");
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");



            // Make API call and return response
            return await client.PostAsync(Endpoints.PostBooking(), content);

            //// Deserialize Content
            //var responseData = JsonConvert.DeserializeObject<BookingResponseJsonModel>(httpResponse.Content.ReadAsStringAsync().Result);

            //return responseData.BookingId;

        }

        /// <summary>
        /// Send POST request for Authentication Bearer Token
        /// </summary>
        ///
        //public static async Task<HttpResponseMessage> AddToken(HttpClient client)
        //{
        //    Create data
        //    var credentials = GenerateCredentials.credentials();
        //    var authenticationURL = Endpoints.PostToken();

        //    Create request
        //    var request = JsonConvert.SerializeObject(credentials);
        //    HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    Make API call and return response
        //    return await client.PostAsync(authenticationURL, content);

        //}

        /// <summary>
        /// Make DELETE Request to delete booking 
        /// </summary>
        ///
        public static async Task<HttpResponseMessage> DeleteBooking(HttpClient client, long id)
        {

            // Make API call and return response
            return await client.DeleteAsync(Endpoints.DeleteBooking(id));
        }


    }
}
