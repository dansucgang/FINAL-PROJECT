using RestSharpProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Tests.Test_Data
{
    public class AuthTokenDetails
    {
        public static TokenDetailsModel credentials()
        {
            return new TokenDetailsModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
