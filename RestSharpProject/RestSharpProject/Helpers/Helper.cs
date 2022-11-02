using RestSharp;
using RestSharpProject.DataModels;
using RestSharpProject.Resources;
using RestSharpProject.Tests.Test_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Helpers
{
    public class Helper
    {
        public static async Task<RestResponse<BookingIdModel>> CreateBooking(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoint.BaseBookingMethod).AddJsonBody(BookingDetails.bookingDetails());

            return await restClient.ExecutePostAsync<BookingIdModel>(postRequest);

        }

        public static async Task<RestResponse<BookingDetailsModel>> GetBook(RestClient restClient, int bookingId)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var getRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId));

            return await restClient.ExecuteGetAsync<BookingDetailsModel>(getRequest);
        }

        public static async Task<RestResponse> DeleteBooking(RestClient restClient, int bookingId)
        {
            var token = await GetToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var getRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId));

            return await restClient.DeleteAsync(getRequest);
        }

        public static async Task<RestResponse<BookingDetailsModel>> UpdateBooking(RestClient restClient, BookingDetailsModel booking, int bookingId)
        {
            var token = await GetToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var putRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId)).AddJsonBody(booking);

            return await restClient.ExecutePutAsync<BookingDetailsModel>(putRequest);
        }

        private static async Task<string> GetToken(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoint.GenerateToken).AddJsonBody(AuthTokenDetails.credentials());

            var generateToken = await restClient.ExecutePostAsync<TokenModel>(postRequest);

            return generateToken.Data.Token;
        }
    }
}
