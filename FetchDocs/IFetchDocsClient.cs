//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

using FetchDocs.Models;
using System.Threading.Tasks;

namespace FetchDocs
{
    public interface IFetchDocsClient
    {
        ///// <summary>
        ///// https://fetchdocs.io/api/v1/index.html#activatecustomer
        ///// </summary>
        ///// <param name="customerId"></param>
        ///// <returns></returns>
        //Task ActivateCustomerAsync(int customerId);

        /// <summary>
        /// https://fetchdocs.io/api/v1/index.html#createcustomer_post
        /// </summary>
        /// <returns></returns>
        Task<FetchDocsApiResponse<CreateCustomerData>> CreateCustomerAsync();

        ///// <summary>
        ///// https://fetchdocs.io/api/v1/index.html#createcustomersupplier
        ///// </summary>
        ///// <param name="supplierId"></param>
        ///// <returns></returns>
        //Task<FetchDocsApiResponse<object>> CreateCustomerSupplierAsync(int supplierId);

        ///// <summary>
        ///// https://fetchdocs.io/api/v1/index.html#createenvironment
        ///// </summary>
        ///// <returns></returns>
        //Task CreateEnvironment();        

        /// <summary>
        /// https://fetchdocs.io/api/v1/index.html#listcustomersuppliers
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="withSupplierLogos"></param>
        /// <returns></returns>
        Task<FetchDocsApiResponse<CustomerSupplierData[]>> ListCustomerSuppliersAsync(int customerId, bool withSupplierLogos = false);

        /// <summary>
        /// https://fetchdocs.io/api/v1/index.html#listsuppliers
        /// </summary>
        /// <param name="withSupplierLogos"></param>
        /// <returns></returns>
        Task<FetchDocsApiResponse<SupplierData[]>> ListSuppliersAsync(bool withSupplierLogos = false);
    }
}
