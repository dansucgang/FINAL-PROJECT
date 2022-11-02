using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.DataModels
{
    class BookingDetailsModel
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("totalprice")]
        public long TotalPrice { get; set; }

        [JsonProperty("depositpaid")]
        public bool DepositPaid { get; set; }

        [JsonProperty("bookingdates")]
        public Bookingdates BookingDates { get; set; }

        [JsonProperty("additionalneeds")]
        public string AdditionalNeeds { get; set; }
    }

    public partial class Bookingdates
    {
        [JsonProperty("checkin")]
        public DateTime Checkin { get; set; }

        [JsonProperty("checkout")]
        public DateTime Checkout { get; set; }
    }
}
