using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Rest_Sharp.DataModels;

namespace Rest_Sharp.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public BookingResponseJsonModel bookingDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }

    }
}
