using RestSharpProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Tests.Test_Data
{
    public class BookingDetails
    {
        public static BookingDetailsModel bookingDetails()
        {
            DateTime dt = DateTime.UtcNow.Date;

            Bookingdates bookingDates = new Bookingdates();
            bookingDates.Checkin = dt;
            bookingDates.Checkout = dt.AddDays(2);

            return new BookingDetailsModel
            {
                Firstname = "SampleFName",
                Lastname = "SampleLName",
                Totalprice = 500,
                Depositpaid = true,
                Bookingdates = bookingDates,
                Additionalneeds = "Nothing"
            };
        }
    }
}
