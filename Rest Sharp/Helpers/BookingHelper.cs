using RestSharp;
using Rest_Sharp.DataModels;
using Rest_Sharp.Resources;
using Rest_Sharp.Tests.TestData;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rest_Sharp.Helpers;
using System.Net;
using Newtonsoft.Json;
using System;

namespace Rest_Sharp.Helpers
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
        public static async Task<BookingResponseJsonModel> AddNewBooking(RestClient client)
        {

            // Initialization
            client = new RestClient();
            client.AddDefaultHeader("Accept", "application/json");

            var generateBookingDetails = GenerateBooking.clientBooking();
            var postRequestEndpoint = Endpoints.PostBooking();

            // POST request
            var postRequest = new RestRequest(postRequestEndpoint)
                .AddJsonBody(generateBookingDetails);

            // POST response for add new booking      
            var postResponse = await client.ExecutePostAsync<BookingResponseJsonModel>(postRequest);

            return postResponse.Data;

        }

        ///// <summary>
        ///// Send GET request to get new booking id
        ///// </summary>
        /////
        //public async Task<BookingResponseJsonModel> GetNewBookingId(RestClient client)
        //{

        //    var getRequest = new RestRequest(Endpoints.GetBookingIds());

        //    //GET response for new booking id
        //    var getResponse = await client.ExecuteGetAsync<BookingResponseJsonModel>(getRequest);

        //    var getBookingId = getResponse.Data.BookingId;

        //    return getBookingId;

        //}

        /// <summary>
        /// Send POST request for Authentication Bearer Token
        /// </summary>
        ///
        public static async Task<TokenJsonModel> AddToken(RestClient client)
        {

            // Initialize Request

            var authenticationURL = Endpoints.PostToken();
            var authenticationData = "{\"username\":\"admin\",\"password\":\"password123\"}";

            // Send Auth Post Request
            var authenticationRequest = new RestRequest(authenticationURL)
                .AddBody(authenticationData, ContentType.Json);
            var authenticationResponse = await client.ExecutePostAsync<TokenJsonModel>(authenticationRequest);

            var token = authenticationResponse.Data;
            return token;       
        }



    }
}
