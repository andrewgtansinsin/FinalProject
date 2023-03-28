using Newtonsoft.Json;

namespace Rest_Sharp.DataModels
{

    /// <summary>
    /// Token JSON Model
    /// </summary>
    public class TokenJsonModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    /// <summary>
    /// Booking Response JSON Model
    /// </summary>
    public class BookingResponseJsonModel
    {
        [JsonProperty("bookingid")]
        public long BookingId { get; set; }

        [JsonProperty("booking")]
        public BookingJsonModel Booking { get; set; }

    }

    /// <summary>
    /// Booking JSON Model
    /// </summary>
    public class BookingJsonModel
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("totalprice")]
        public long Totalprice { get; set; }

        [JsonProperty("depositpaid")]
        public bool Depositpaid { get; set; }

        [JsonProperty("bookingdates")]
        public Bookingdates Bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; }
    }

    /// <summary>
    /// Bookingdates JSON Model
    /// </summary>
    public class Bookingdates
    {
        [JsonProperty("checkin")]
        public string Checkin { get; set; }

        [JsonProperty("checkout")]
        public string Checkout { get; set; }
    }


}
