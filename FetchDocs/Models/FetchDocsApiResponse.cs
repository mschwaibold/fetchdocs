//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

namespace FetchDocs.Models
{
    public class FetchDocsApiResponse<TData>
    {
        public bool Success { get; set; }
        public TData Data { get; set; }
        public string Code { get; set; }
        public string Detail { get; set; }
    }
}
