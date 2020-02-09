//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FetchDocs.Integration.Tests
{
    [TestClass]
    public class FetchDocsClientTests
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;
        private readonly int _accountId;

        public FetchDocsClientTests()
        {
            _apiKey = ConfigurationManager.AppSettings.Get("FetchDocsApiKey");
            _apiUrl = ConfigurationManager.AppSettings.Get("FetchDocsApiUrl");
            _accountId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("FetchDocsAccountId"));
        }

        [TestMethod]
        public async Task CreateCustomerAsyncSuccess()
        {
            var sendResponse = new Func<HttpListenerRequest, string>(request => 
            {
                return "{\"success\": true, \"data\": {\"prim_uid\": 1, \"customer_secret\": \"customer_secret\", \"access_token\": \"customer_access_token\"}}";
            });

            var ws = new WebServer(sendResponse, _apiUrl);
            ws.Run();

            IFetchDocsClient client = new FetchDocsClient(-1, null, _apiUrl);

            var response = await client.CreateCustomerAsync();

            Assert.AreEqual(1, response.Data.Id);
            Assert.AreEqual("customer_secret", response.Data.Secret);
            Assert.AreEqual("customer_access_token", response.Data.AccessToken);

            ws.Stop();
        }

        [TestMethod]
        public async Task ListSuppliersAsyncSuccess()
        {
            var sendResponse = new Func<HttpListenerRequest, string>(request =>
            {
                return "{\"success\": true, \"data\": [{\"prim_uid\": 1, \"name\": \"1&1.de\", \"created\": \"2018-02-12 12:52:38\"}, {\"prim_uid\": 2, \"name\": \"test\", \"created\": \"2020-02-09 17:51:58\"}]}";
            });

            var ws = new WebServer(sendResponse, _apiUrl);
            ws.Run();

            IFetchDocsClient client = new FetchDocsClient(-1, null, _apiUrl);

            var response = await client.ListSuppliersAsync();

            Assert.AreEqual(2, response.Data.Length);
            Assert.AreEqual(2, response.Data[1].Id);
            Assert.AreEqual("test", response.Data[1].Name);
            Assert.AreEqual(new DateTime(2020,2,9,17,51,58), response.Data[1].Created);

            ws.Stop();
        }
    }
}
