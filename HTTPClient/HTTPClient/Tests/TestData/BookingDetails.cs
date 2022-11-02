using HTTPClient.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Tests.TestData
{
    class BookingDetails
    {
        public static BookingDetailsModel bookingDetails()
        {
            DateTime dt = DateTime.UtcNow.Date;

            Bookingdates bookingDates = new Bookingdates();
            bookingDates.Checkin = dt;
            bookingDates.Checkout = dt.AddDays(1);

            return new BookingDetailsModel
            {
                FirstName = "SampleFName",
                LastName = "SampleLName",
                TotalPrice = 500,
                DepositPaid = true,
                BookingDates = bookingDates,
                AdditionalNeeds = "Breakfast"
            };
        }
    }
}
