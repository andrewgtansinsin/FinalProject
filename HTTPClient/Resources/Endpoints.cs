using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTTPClient.Resources
{
    /// <summary>
    /// Class containing all endpoints used in API tests
    /// </summary>
    public class Endpoints
    {
        //Base URL
        public static string baseURL = "https://restful-booker.herokuapp.com/";

        //public static string GetURL(string endpoint) => $"{baseURL}{endpoint}";

        //private static Uri GetURI(string endpoint) => new Uri(GetURL(endpoint));

        //Auth - Create Token
        public static string PostToken() => $"{baseURL}auth";

        //Booking - GetBookingIds
        public static string GetBookingIds() => $"{baseURL}booking";

        //Booking - GetBooking
        public static string GetBooking(long bookingId) => $"{baseURL}booking/{bookingId}";

        //Booking - Create Booking
        public static string PostBooking() => $"{baseURL}booking";

        //Booking - Update Booking
        public static string PutBooking(long bookingId) => $"{baseURL}booking/{bookingId}";

        //Booking - Delete Booking
        public static string DeleteBooking(long bookingId) => $"{baseURL}booking/{bookingId}";
    }
}
