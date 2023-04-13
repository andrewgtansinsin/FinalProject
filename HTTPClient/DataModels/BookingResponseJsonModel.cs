using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.DataModels
{
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
}
