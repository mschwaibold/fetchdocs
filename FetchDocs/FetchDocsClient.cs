//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

using FetchDocs.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FetchDocs
{
    public class FetchDocsClient : IFetchDocsClient
    {
        private readonly int _accountId;
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public FetchDocsClient(int accountId, string apiKey, string apiUrl)
        {
            _apiKey = apiKey;
            _apiUrl = apiUrl;
            _accountId = accountId;
        }

        //public async Task<bool> ActivateCustomerAsync(int customerId, string secret, string accessToken)
        //{
        //    var body = new JObject
        //    {
        //        { JPName.PrimUid, customerId },
        //        { JPName.CustomerSecret, secret },
        //        { JPName.AccessToken, accessToken }
        //    };

        //    var response = await GetResponse<bool>("activateCustomer", body);
        //}

        //public async Task CreateEnvironmentAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<FetchDocsApiResponse<CreateCustomerData>> CreateCustomerAsync()
        {
            return await GetResponse<CreateCustomerData>("createCustomer");
        }

        //public async Task CreateCustomerSupplier(int supplierId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task GetCustomerAsync(int customerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task GetCustomerSessionAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<FetchDocsApiResponse<CustomerSupplierData[]>> ListCustomerSuppliersAsync(int customerId, bool withSupplierLogos = false)
        {
            var body = new JObject
            {
                { PName.PrimUid, customerId },
                { PName.WithSupplierLogos, withSupplierLogos }
            };

            return await GetResponse<CustomerSupplierData[]>("listCustomerSuppliers", body);
        }

        public async Task<FetchDocsApiResponse<SupplierData[]>> ListSuppliersAsync(bool withSupplierLogos = false)
        {
            var body = new JObject { { PName.WithSupplierLogos, withSupplierLogos } };

            return await GetResponse<SupplierData[]>("listSuppliers", body);
        }

        #region --- Private -------------------------------------------------------------------------------------------

        private string GetUrl(string apiCall)
        {
            return Path.Combine(_apiUrl, apiCall);
        }

        private async Task<FetchDocsApiResponse<TData>> GetResponse<TData>(string apiCall)
        {
            return await GetResponse<TData>(apiCall, new JObject());
        }

        private async Task<FetchDocsApiResponse<TData>> GetResponse<TData>(string apiCall, JObject body)
        {
            var url = GetUrl(apiCall);

            body.Add(PName.ApiKey, _apiKey);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            using (var client = new HttpClient())
            {
                request.Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");

                var httpResponse = await client.SendAsync(request);
                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<FetchDocsApiResponse<TData>>(jsonResponse);

                return response;
            }
        }

        #endregion --- Private ----------------------------------------------------------------------------------------
    }
}
