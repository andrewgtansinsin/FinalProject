using HTTPClient.DataModels;
using System;

namespace HTTPClient.Tests.TestData
{
    public class GenerateCredentials
    {

        public static TokenJsonModel credentials()
        {
            return new TokenJsonModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
