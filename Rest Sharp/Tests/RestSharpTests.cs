using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rest_Sharp.Helpers;
using Rest_Sharp.Resources;
using Rest_Sharp.DataModels;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using Rest_Sharp.Tests.TestData;


namespace Rest_Sharp.Tests
{
    [TestClass]
    public class RestSharpTests : ApiBaseTest
    {
        private static List<BookingResponseJsonModel> bookingCleanUpList = new List<BookingResponseJsonModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            bookingDetails = await BookingHelper.AddNewBooking(RestClient);
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {

            foreach (var data in bookingCleanUpList)
            {
                var TokenDetails = await BookingHelper.AddToken(RestClient);
                var deleteRequestEndpoint = Endpoints.DeleteBooking(data.BookingId);
                var deleteBookingRequest = new RestRequest(deleteRequestEndpoint)
                    .AddHeader("Cookie", $"token={TokenDetails.Token}");
                var deleteBookingResponse = await RestClient.DeleteAsync(deleteBookingRequest);

            }

        }

        [TestMethod]
        public async Task ClientCreatedBooking()
        {

            // Get Booking Id
            // Arrange
            var generateBookingDetails = GenerateBooking.clientBooking();
            var getBookingId = bookingDetails.BookingId;
            var clientGetRequest = new RestRequest(Endpoints.GetBooking(getBookingId)).AddHeader("Accept", "application/json");

            // CleanUp
            bookingCleanUpList.Add(bookingDetails);

            // Act
            var clientBookingResponse = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest);

            // Assert
            Assert.IsNotNull(clientBookingResponse, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.OK, clientBookingResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(generateBookingDetails.Firstname, clientBookingResponse.Data.Firstname, "First name did not match");
            Assert.AreEqual(generateBookingDetails.Lastname, clientBookingResponse.Data.Lastname, "Last name did not match");
            Assert.AreEqual(generateBookingDetails.Totalprice, clientBookingResponse.Data.Totalprice, "Total price did not match");
            Assert.AreEqual(generateBookingDetails.Depositpaid, clientBookingResponse.Data.Depositpaid, "Deposit paid did not match");
            Assert.AreEqual(generateBookingDetails.Bookingdates.Checkin, clientBookingResponse.Data.Bookingdates.Checkin, "Checkin did not match");
            Assert.AreEqual(generateBookingDetails.Bookingdates.Checkout, clientBookingResponse.Data.Bookingdates.Checkout, "Checkout did not match");
            Assert.AreEqual(generateBookingDetails.Additionalneeds, clientBookingResponse.Data.Additionalneeds, "Additional needs did not match");
            foreach (PropertyInfo property in generateBookingDetails.Bookingdates.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(generateBookingDetails.Bookingdates), property.GetValue(clientBookingResponse.Data.Bookingdates), $"Booking dates {property} mismatch");
            }

        }

        [TestMethod]
        public async Task ClientUpdatedBooking()
        {
            // Get Booking Id
            // Arrange
            var generateBookingDetails = GenerateBooking.clientBooking();
            var TokenDetails = await BookingHelper.AddToken(RestClient);
            var getBookingId = bookingDetails.BookingId;
            var clientGetRequest = new RestRequest(Endpoints.GetBooking(getBookingId))
                .AddHeader("Accept", "application/json");

            // Act
            var clientBookingResponse = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest);

            // Assert
            Assert.IsNotNull(clientBookingResponse, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.OK, clientBookingResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(generateBookingDetails.Firstname, clientBookingResponse.Data.Firstname, "First name did not match");
            Assert.AreEqual(generateBookingDetails.Lastname, clientBookingResponse.Data.Lastname, "Last name did not match");

            // Update Booking Details
            // Arrange
            var generateUpdatedBookingDetails = GenerateBooking.updateclientBooking();
            var putRequestEndpoint = Endpoints.PutBooking(getBookingId);
            var clientPutRequest = new RestRequest(putRequestEndpoint)
                .AddHeader("Accept", "application/json")
                .AddHeader("Cookie", $"token={TokenDetails.Token}")
                .AddJsonBody(generateUpdatedBookingDetails);

            // Act
            var clientPutResponse = await RestClient.ExecutePutAsync<BookingResponseJsonModel>(clientPutRequest);

            // Assert
            Assert.IsNotNull(clientPutResponse, "Result from PUT is null");
            Assert.AreEqual(HttpStatusCode.OK, clientPutResponse.StatusCode, "Failed due to wrong status code.");

            // Get Updated Booking Details
            // Arrange
            var clientUpdateGetRequest = new RestRequest(Endpoints.GetBooking(getBookingId))
                .AddHeader("Accept", "application/json");

            // CleanUp
            bookingCleanUpList.Add(bookingDetails);


            // Act
            var clientUpdateBookingResponse = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientUpdateGetRequest);

            // Assert
            Assert.IsNotNull(clientUpdateBookingResponse, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.OK, clientUpdateBookingResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(generateUpdatedBookingDetails.Firstname, clientUpdateBookingResponse.Data.Firstname, "First name did not match");
            Assert.AreEqual(generateUpdatedBookingDetails.Lastname, clientUpdateBookingResponse.Data.Lastname, "Last name did not match");
            Assert.AreEqual(generateUpdatedBookingDetails.Totalprice, clientUpdateBookingResponse.Data.Totalprice, "Total price did not match");
            Assert.AreEqual(generateUpdatedBookingDetails.Depositpaid, clientUpdateBookingResponse.Data.Depositpaid, "Deposit paid did not match");
            Assert.AreEqual(generateUpdatedBookingDetails.Bookingdates.Checkin, clientUpdateBookingResponse.Data.Bookingdates.Checkin, "Checkin did not match");
            Assert.AreEqual(generateUpdatedBookingDetails.Bookingdates.Checkout, clientUpdateBookingResponse.Data.Bookingdates.Checkout, "Checkout did not match");
            Assert.AreEqual(generateUpdatedBookingDetails.Additionalneeds, clientUpdateBookingResponse.Data.Additionalneeds, "Additional needs did not match");
            foreach (PropertyInfo property in generateUpdatedBookingDetails.Bookingdates.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(generateUpdatedBookingDetails.Bookingdates), property.GetValue(clientUpdateBookingResponse.Data.Bookingdates), $"Booking dates {property} mismatch");
            }

        }

        [TestMethod]
        public async Task ClientDeleteBooking()
        {
            // Get Booking Id
            // Arrange
            var generateBookingDetails = GenerateBooking.clientBooking();
            var TokenDetails = await BookingHelper.AddToken(RestClient);
            var getBookingId = bookingDetails.BookingId;
            var clientGetRequest = new RestRequest(Endpoints.GetBooking(getBookingId))
                .AddHeader("Accept", "application/json");

            // Act
            var clientBookingResponse = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest);

            // Assert
            Assert.IsNotNull(clientBookingResponse, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.OK, clientBookingResponse.StatusCode, "Failed due to wrong status code.");

            // Delete Created Booking
            // Arrange
            var deleteRequestEndpoint = Endpoints.DeleteBooking(getBookingId);
            var deleteBookingRequest = new RestRequest(deleteRequestEndpoint)
                .AddHeader("Cookie", $"token={TokenDetails.Token}");

            // Act
            var deleteBookingResponse = await RestClient.DeleteAsync(deleteBookingRequest);

            // Assertion
            Assert.AreEqual(HttpStatusCode.Created, deleteBookingResponse.StatusCode, "Status code is not equal to 200");

            // Verify if user exist
            // Arrange
            var clientRequest = new RestRequest(Endpoints.GetBooking(getBookingId))
                .AddHeader("Accept", "application/json");


            // Act
            var clientResponse = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientRequest);

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, clientResponse.StatusCode, "Status code is not equal to 404. User still exist");


        }

        [TestMethod]
        public async Task InvalidBookingId()
        {

            // Get Booking Id - Negative Booking ID
            // Arrange
            var getBookingId1 = -(bookingDetails.BookingId);
            var clientGetRequest1 = new RestRequest(Endpoints.GetBooking(getBookingId1))
                .AddHeader("Accept", "application/json");

            // Act
            var clientBookingResponse1 = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest1);

            // Assert
            Assert.IsNotNull(clientBookingResponse1, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.NotFound, clientBookingResponse1.StatusCode, "Failed due to wrong status code.");

            // Get Booking Id - Zero Booking ID
            // Arrange
            var getBookingId2 = 0;
            var clientGetRequest2 = new RestRequest(Endpoints.GetBooking(getBookingId2))
                .AddHeader("Accept", "application/json");

            // Act
            var clientBookingResponse2 = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest2);

            // Assert
            Assert.IsNotNull(clientBookingResponse2, "Result from GET is null");
            Assert.AreEqual(HttpStatusCode.NotFound, clientBookingResponse2.StatusCode, "Failed due to wrong status code.");
        }

    }
}
