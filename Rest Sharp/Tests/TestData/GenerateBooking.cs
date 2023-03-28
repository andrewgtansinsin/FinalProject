using Rest_Sharp.DataModels;
using System;

namespace Rest_Sharp.Tests.TestData
{
    public class GenerateBooking
    {

        public static BookingJsonModel clientBooking()
        {
            return new BookingJsonModel
            {
                Firstname = "Andrin",
                Lastname = "Acielo",
                Totalprice = 123,
                Depositpaid = true,
                Bookingdates = new Bookingdates
                {
                    Checkin = "2023-08-19",
                    Checkout = "2023-08-23"
                },
                Additionalneeds = "Brekky"

            };
        }

        public static BookingJsonModel updateclientBooking()
        {
            return new BookingJsonModel
            {
                Firstname = "Aldrew",
                Lastname = "Tansinsin",
                Totalprice = 123,
                Depositpaid = true,
                Bookingdates = new Bookingdates
                {
                    Checkin = "2023-08-19",
                    Checkout = "2023-08-23"
                },
                Additionalneeds = "Brekky"

            };
        }
    }
}
