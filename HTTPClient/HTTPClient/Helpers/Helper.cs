using HTTPClient.DataModels;
using HTTPClient.Resource;
using HTTPClient.Tests.TestData;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HTTPClient.Helpers
{

    class Helper
    {
        private HttpClient httpClient;


        private async Task<string> GetToken()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(AuthTokenDetails.credentials());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync(Endpoint.GetURL(Endpoint.AuthEndpoint), postRequest);

            var token = JsonConvert.DeserializeObject<TokenModel>(httpResponse.Content.ReadAsStringAsync().Result);

            return token.Token;
        }
        public async Task<HttpResponseMessage> CreateBooking()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(BookingDetails.bookingDetails());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(Endpoint.GetURL(Endpoint.UserEndpoint), postRequest);
        }

        public async Task<HttpResponseMessage> GetBooking(int bookingId)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return await httpClient.GetAsync(Endpoint.GetUri(Endpoint.UserEndpoint) + "/" + bookingId);
        }

        public async Task<HttpResponseMessage> DeleteBooking(int bookingId)
        {
            var token = await GetToken();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);
            return await httpClient.DeleteAsync(Endpoint.GetUri(Endpoint.UserEndpoint) + "/" + bookingId);
        }

        public async Task<HttpResponseMessage> UpdateBooking(BookingDetailsModel booking, int bookingId)
        {
            var token = await GetToken();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);

            var request = JsonConvert.SerializeObject(booking);
            var putRequest = new StringContent(request, Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(Endpoint.GetURL(Endpoint.UserEndpoint + "/" + bookingId), putRequest);
        }
    }
}

