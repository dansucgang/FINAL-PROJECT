using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpProject.DataModels;
using RestSharpProject.Helpers;
using RestSharpProject.Tests.Test_Data;
using System.Net;

namespace RestSharpProject.Tests
{
    [TestClass]
    public class RestSharpTests : APIBaseTest
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            //Create Data
            var restResponse = await Helper.CreateBooking(RestClient);
            BookingDetails = restResponse.Data;


            //Assertion
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task CreateBooking()
        {
            //Create Data
            var getBookingResponse = await Helper.GetBook(RestClient, BookingDetails.BookingId);


            //ASsertion
            var expectedBookingDetails = RestSharpProject.Tests.Test_Data.BookingDetails.bookingDetails();
            Assert.AreEqual(expectedBookingDetails.Firstname, getBookingResponse.Data.Firstname, "Firstname doesn't Match .");
            Assert.AreEqual(expectedBookingDetails.Lastname, getBookingResponse.Data.Lastname, "Lastname doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Totalprice, getBookingResponse.Data.Totalprice, "Totalprice doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Depositpaid, getBookingResponse.Data.Depositpaid, "Depositpaid doesn't match.");
            Assert.AreEqual(expectedBookingDetails.Bookingdates.Checkin, getBookingResponse.Data.Bookingdates.Checkin, "Checkin dates doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Bookingdates.Checkout, getBookingResponse.Data.Bookingdates.Checkout, "Checkout dates doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Additionalneeds, getBookingResponse.Data.Additionalneeds, "Additional needs doesn't  match.");


            //Clean Up
            await Helper.DeleteBooking(RestClient, BookingDetails.BookingId);

        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            //Create Data
            var getBookingResponse = await Helper.GetBook(RestClient, BookingDetails.BookingId);


            //Update Data 
            var updateBookingDetails = new BookingDetailsModel()
            {
                Firstname = "SampleFNameUpdated",
                Lastname = "SampleLNameUpdated",
                Totalprice = getBookingResponse.Data.Totalprice,
                Depositpaid = getBookingResponse.Data.Depositpaid,
                Bookingdates = getBookingResponse.Data.Bookingdates,
                Additionalneeds = getBookingResponse.Data.Additionalneeds
            };
            var updateBooking = await Helper.UpdateBooking(RestClient, updateBookingDetails, BookingDetails.BookingId);

            //Assertion
            Assert.AreEqual(updateBooking.StatusCode, HttpStatusCode.OK);


            //Get Updated Data 
            var getUpdatedBookingResponse = await Helper.GetBook(RestClient, BookingDetails.BookingId);


            //Assertion
            Assert.AreEqual(updateBookingDetails.Firstname, getUpdatedBookingResponse.Data.Firstname, "Firstname doesn't  match.");
            Assert.AreEqual(updateBookingDetails.Lastname, getUpdatedBookingResponse.Data.Lastname, "Lastname doesn't  match.");
            Assert.AreEqual(updateBookingDetails.Totalprice, getUpdatedBookingResponse.Data.Totalprice, "Totalprice doesn't match.");
            Assert.AreEqual(updateBookingDetails.Depositpaid, getUpdatedBookingResponse.Data.Depositpaid, "Depositpaid doesn't match.");
            Assert.AreEqual(updateBookingDetails.Bookingdates.Checkin, getUpdatedBookingResponse.Data.Bookingdates.Checkin, "Checkin dates doesn't  match.");
            Assert.AreEqual(updateBookingDetails.Bookingdates.Checkout, getUpdatedBookingResponse.Data.Bookingdates.Checkout, "Checkout dates doesn't t match.");
            Assert.AreEqual(updateBookingDetails.Additionalneeds, getUpdatedBookingResponse.Data.Additionalneeds, "Additional needs doesn't  match.");

            //Clean Up
            await Helper.DeleteBooking(RestClient, BookingDetails.BookingId);

        }

        [TestMethod]
        public async Task DeleteBooking()
        {
            //Delete Data
            var deleteBooking = await Helper.DeleteBooking(RestClient, BookingDetails.BookingId);
           

            //Assertion
            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created);
        
        }

        [TestMethod]
        public async Task ValidateInvalidBooking()
        {
           //Create Data
            var getCreatedBooking = await Helper.GetBook(RestClient, 123456789);


           //Assertion
            Assert.AreEqual(getCreatedBooking.StatusCode, HttpStatusCode.NotFound);
   

            //Clean up
            await Helper.DeleteBooking(RestClient, BookingDetails.BookingId);
 
        }
    }
}