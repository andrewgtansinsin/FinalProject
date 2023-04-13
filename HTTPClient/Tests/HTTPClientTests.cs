using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTTPClient.Helpers;
using HTTPClient.Resources;
using HTTPClient.DataModels;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Reflection;
using HTTPClient.Tests.TestData;
using System.Text;
using System.Net.Http.Headers;


namespace HTTPClient.Tests
{
    [TestClass]
    public class HTTPClientTests : BaseTest
    {
        private static List<BookingResponseJsonModel> bookingCleanUpList = new List<BookingResponseJsonModel>();

        [TestInitialize]
        public void TestInitialize()
        {
            //bookingDetails = await BookingHelper.AddNewBooking(httpClient);
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {

            foreach (var data in bookingCleanUpList)
            {
                await BookingHelper.DeleteBooking(httpClient, data.BookingId);
            }

        }

        [TestMethod]
        public async Task ClientCreatedBooking()
        {
            //httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpResponse = BookingHelper.AddNewBooking(httpClient);
            var responsedata = JsonConvert.DeserializeObject<BookingResponseJsonModel>(httpResponse.Content.ReadAsStringAsync().Result);

            //    // Get Booking Id
            //    // Arrange
            //    HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            //    var generateBookingDetails = GenerateBooking.clientBooking();
            //    var getBookingId = bookingDetails.BookingId;
            //    var getRequestEndpoint = Endpoints.GetBooking(getBookingId);

            //    // Serialize Content
            //    var request = JsonConvert.SerializeObject(generateBookingDetails);
            //    httpRequestMessage.Content = new StringContent(request, Encoding.UTF8, "application/json");

            //    // Set Request Method
            //    httpRequestMessage.Method = HttpMethod.Get;

            //    // Set Request Header
            //    httpRequestMessage.Headers.Add("Accept", "application/json");

            //    // Set Request URI
            //    httpRequestMessage.RequestUri = getRequestEndpoint;

            //    // CleanUp
            //    bookingCleanUpList.Add(bookingDetails);


            //    // Act
            //    // Send Request
            //    var httpResponse = await httpClient.SendAsync(httpRequestMessage);

            //    // Deserialize Content
            //    var responseData = JsonConvert.DeserializeObject<BookingJsonModel>(httpResponse.Content.ReadAsStringAsync().Result);


            //    // Assert
            //    Assert.IsNotNull(httpResponse, "Result from GET is null");
            //    Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode, "Failed due to wrong status code.");
            //    Assert.AreEqual(generateBookingDetails.Firstname, responseData.Firstname, "First name did not match");
            //    Assert.AreEqual(generateBookingDetails.Lastname, responseData.Lastname, "Last name did not match");
            //    Assert.AreEqual(generateBookingDetails.Totalprice, responseData.Totalprice, "Total price did not match");
            //    Assert.AreEqual(generateBookingDetails.Depositpaid, responseData.Depositpaid, "Deposit paid did not match");
            //    Assert.AreEqual(generateBookingDetails.Bookingdates.Checkin, responseData.Bookingdates.Checkin, "Checkin did not match");
            //    Assert.AreEqual(generateBookingDetails.Bookingdates.Checkout, responseData.Bookingdates.Checkout, "Checkout did not match");
            //    Assert.AreEqual(generateBookingDetails.Additionalneeds, responseData.Additionalneeds, "Additional needs did not match");
            //    foreach (PropertyInfo property in generateBookingDetails.Bookingdates.GetType().GetProperties())
            //    {
            //        Assert.AreEqual(property.GetValue(generateBookingDetails.Bookingdates), property.GetValue(responseData.Bookingdates), $"Booking dates {property} mismatch");
            //    }

        }

        [TestMethod]
        public async Task ClientUpdatedBooking()
        {
            //// Get Booking Id
            //// Arrange
            //HttpRequestMessage httpRequestGetMessage = new HttpRequestMessage();
            //var generateBookingDetails = GenerateBooking.clientBooking();
            //var TokenDetails = await BookingHelper.AddToken(httpClient);
            ////var getBookingId = bookingDetails.BookingId;
            //var getRequestEndpoint = Endpoints.GetBooking(getBookingId);

            //// Serialize Content
            //var requestGet = JsonConvert.SerializeObject(generateBookingDetails);
            //httpRequestGetMessage.Content = new StringContent(requestGet, Encoding.UTF8, "application/json");

            //// Set Request Method
            //httpRequestGetMessage.Method = HttpMethod.Get;

            //// Set Request Header
            //httpRequestGetMessage.Headers.Add("Accept", "application/json");

            //// Set Request URI
            //httpRequestGetMessage.RequestUri = getRequestEndpoint;


            //// Act
            //// Send Request
            //var httpGetResponse = await httpClient.SendAsync(httpRequestGetMessage);

            //// Deserialize Content
            //var responseGetData = JsonConvert.DeserializeObject<BookingJsonModel>(httpGetResponse.Content.ReadAsStringAsync().Result);

            //// Assert
            //Assert.IsNotNull(httpGetResponse, "Result from GET is null");
            //Assert.AreEqual(HttpStatusCode.OK, httpGetResponse.StatusCode, "Failed due to wrong status code.");
            //Assert.AreEqual(generateBookingDetails.Firstname, responseGetData.Firstname, "First name did not match");
            //Assert.AreEqual(generateBookingDetails.Lastname, responseGetData.Lastname, "Last name did not match");


            //// Update Booking Details
            //// Arrange
            //HttpRequestMessage httpRequestPutMessage = new HttpRequestMessage();
            //var generateUpdatedBookingDetails = GenerateBooking.updateclientBooking();
            ////var putRequestEndpoint = Endpoints.PutBooking(getBookingId);

            //// Serialize Content
            //var requestPut = JsonConvert.SerializeObject(generateUpdatedBookingDetails);
            //httpRequestPutMessage.Content = new StringContent(requestPut, Encoding.UTF8, "application/json");

            //// Set Request Method
            //httpRequestPutMessage.Method = HttpMethod.Put;

            //// Set Request Header
            //httpRequestPutMessage.Headers.Add("Accept", "application/json");
            //httpRequestPutMessage.Headers.Add("Cookie", $"token={TokenDetails}");

            //// Set Request URI
            //httpRequestPutMessage.RequestUri = putRequestEndpoint;

            //// Act
            //// Send Request
            //var httpPutResponse = await httpClient.SendAsync(httpRequestPutMessage);

            //// Deserialize Content
            //var responsePutData = JsonConvert.DeserializeObject<BookingJsonModel>(httpPutResponse.Content.ReadAsStringAsync().Result);


            //// Assert
            //Assert.IsNotNull(httpPutResponse, "Result from PUT is null");
            //Assert.AreEqual(HttpStatusCode.OK, httpPutResponse.StatusCode, "Failed due to wrong status code.");

            //// Get Updated Booking Details
            //// Arrange
            //HttpRequestMessage httpRequestUpdatedGetMessage = new HttpRequestMessage();

            //// Serialize Content
            //var requestUpdatedGet = JsonConvert.SerializeObject(generateBookingDetails);
            //httpRequestUpdatedGetMessage.Content = new StringContent(requestUpdatedGet, Encoding.UTF8, "application/json");

            //// Set Request Method
            //httpRequestUpdatedGetMessage.Method = HttpMethod.Get;

            //// Set Request Header
            //httpRequestUpdatedGetMessage.Headers.Add("Accept", "application/json");

            //// Set Request URI
            //httpRequestUpdatedGetMessage.RequestUri = getRequestEndpoint;

            //// CleanUp
            //bookingCleanUpList.Add(bookingDetails);

            //// Act
            //var httpUpdatedGetResponse = await httpClient.SendAsync(httpRequestUpdatedGetMessage);

            //// Deserialize Content
            //var responseUpdatedGetData = JsonConvert.DeserializeObject<BookingJsonModel>(httpUpdatedGetResponse.Content.ReadAsStringAsync().Result);

            //// Assert
            //Assert.IsNotNull(httpUpdatedGetResponse, "Result from GET is null");
            //Assert.AreEqual(HttpStatusCode.OK, httpUpdatedGetResponse.StatusCode, "Failed due to wrong status code.");
            //Assert.AreEqual(generateUpdatedBookingDetails.Firstname, responseUpdatedGetData.Firstname, "First name did not match");
            //Assert.AreEqual(generateUpdatedBookingDetails.Lastname, responseUpdatedGetData.Lastname, "Last name did not match");
            //Assert.AreEqual(generateUpdatedBookingDetails.Totalprice, responseUpdatedGetData.Totalprice, "Total price did not match");
            //Assert.AreEqual(generateUpdatedBookingDetails.Depositpaid, responseUpdatedGetData.Depositpaid, "Deposit paid did not match");
            //Assert.AreEqual(generateUpdatedBookingDetails.Bookingdates.Checkin, responseUpdatedGetData.Bookingdates.Checkin, "Checkin did not match");
            //Assert.AreEqual(generateUpdatedBookingDetails.Bookingdates.Checkout, responseUpdatedGetData.Bookingdates.Checkout, "Checkout did not match");
            //Assert.AreEqual(generateUpdatedBookingDetails.Additionalneeds, responseUpdatedGetData.Additionalneeds, "Additional needs did not match");
            //foreach (PropertyInfo property in generateUpdatedBookingDetails.Bookingdates.GetType().GetProperties())
            //{
            //    Assert.AreEqual(property.GetValue(generateUpdatedBookingDetails.Bookingdates), property.GetValue(responseUpdatedGetData.Bookingdates), $"Booking dates {property} mismatch");
            //}

        }

        [TestMethod]
        public async Task ClientDeleteBooking()
        {
            //// Get Booking Id
            //// Arrange
            //HttpRequestMessage httpRequestGetMessage = new HttpRequestMessage();
            //var generateBookingDetails = GenerateBooking.clientBooking();
            ////var TokenDetails = await BookingHelper.AddToken(httpClient);
            //var getBookingId = bookingDetails.BookingId;
            //var getRequestEndpoint = Endpoints.GetBooking(getBookingId);

            //// Serialize Content
            //var requestGet = JsonConvert.SerializeObject(generateBookingDetails);
            //httpRequestGetMessage.Content = new StringContent(requestGet, Encoding.UTF8, "application/json");

            //// Set Request Method
            //httpRequestGetMessage.Method = HttpMethod.Get;

            //// Set Request Header
            //httpRequestGetMessage.Headers.Add("Accept", "application/json");

            //// Set Request URI
            //httpRequestGetMessage.RequestUri = getRequestEndpoint;


            //// Act
            //// Send Request
            //var httpGetResponse = await httpClient.SendAsync(httpRequestGetMessage);

            //// Deserialize Content
            //var responseGetData = JsonConvert.DeserializeObject<BookingJsonModel>(httpGetResponse.Content.ReadAsStringAsync().Result);



            //// Assert
            //Assert.IsNotNull(httpGetResponse, "Result from GET is null");
            //Assert.AreEqual(HttpStatusCode.OK, httpGetResponse.StatusCode, "Failed due to wrong status code.");

            //// Delete Created Booking
            //// Arrange
            ////HttpRequestMessage httpRequestDeleteMessage = new HttpRequestMessage();
            //var deleteRequestEndpoint = Endpoints.DeleteBooking(getBookingId);

            //// Serialize Content
            ////var request = JsonConvert.SerializeObject(generateBookingDetails);
            ////var deleteRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //// Set Request Method
            ////httpRequestDeleteMessage.Method = HttpMethod.Delete;

            //// Set Request Header
            ////httpRequestDeleteMessage.Headers.Add("Cookie", $"token={TokenDetails}");

            //// Set Request URI
            ////httpRequestDeleteMessage.RequestUri = deleteRequestEndpoint;

            //// Act
            //// Send Request
            //var httpDeleteResponse = await httpClient.DeleteAsync(deleteRequestEndpoint);

            //// Deserialize Content
            ////var responseDeleteData = JsonConvert.DeserializeObject(httpDeleteResponse.Content.ReadAsStringAsync().Result);


            //// Assertion
            //Assert.AreEqual(HttpStatusCode.Created, httpDeleteResponse.StatusCode, "Status code is not equal to 200");

            //// Verify if user exist
            //// Arrange

            //// Serialize Content
            //var requestGetAgain = JsonConvert.SerializeObject(generateBookingDetails);
            //httpRequestGetMessage.Content = new StringContent(requestGetAgain, Encoding.UTF8, "application/json");

            //// Set Request Method
            //httpRequestGetMessage.Method = HttpMethod.Get;

            //// Set Request Header
            //httpRequestGetMessage.Headers.Add("Accept", "application/json");

            //// Set Request URI
            //httpRequestGetMessage.RequestUri = getRequestEndpoint;


            //// Act
            //// Send Request
            //var httpGetResponseAgain = await httpClient.SendAsync(httpRequestGetMessage);

            //// Deserialize Content
            //var responseGetDataAgain = JsonConvert.DeserializeObject<BookingJsonModel>(httpGetResponseAgain.Content.ReadAsStringAsync().Result);

            //// Assert
            //Assert.AreEqual(HttpStatusCode.NotFound, httpGetResponseAgain.StatusCode, "Status code is not equal to 404. User still exist");


        }

        //[TestMethod]
        //public async Task InvalidBookingId()
        //{

        //    // Get Booking Id - Negative Booking ID
        //    // Arrange
        //    var getBookingId1 = -(bookingDetails.BookingId);
        //    var clientGetRequest1 = new RestRequest(Endpoints.GetBooking(getBookingId1))
        //        .AddHeader("Accept", "application/json");

        //    // Act
        //    var clientBookingResponse1 = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest1);

        //    // Assert
        //    Assert.IsNotNull(clientBookingResponse1, "Result from GET is null");
        //    Assert.AreEqual(HttpStatusCode.NotFound, clientBookingResponse1.StatusCode, "Failed due to wrong status code.");

        //    // Get Booking Id - Zero Booking ID
        //    // Arrange
        //    var getBookingId2 = 0;
        //    var clientGetRequest2 = new RestRequest(Endpoints.GetBooking(getBookingId2))
        //        .AddHeader("Accept", "application/json");

        //    // Act
        //    var clientBookingResponse2 = await RestClient.ExecuteGetAsync<BookingJsonModel>(clientGetRequest2);

        //    // Assert
        //    Assert.IsNotNull(clientBookingResponse2, "Result from GET is null");
        //    Assert.AreEqual(HttpStatusCode.NotFound, clientBookingResponse2.StatusCode, "Failed due to wrong status code.");
        //}

    }
}
