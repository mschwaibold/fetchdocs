//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

using Newtonsoft.Json;

namespace FetchDocs.Models
{
    public abstract class BaseSupplierData
    {
        [JsonProperty(PName.PrimUid)]
        public int Id { get; set; }

        [JsonProperty(PName.SupplierLogoUrl)]
        public string SupplierLogoUrl { get; set; }

        [JsonProperty(PName.SupplierLogo)]
        public string SupplierLogo { get; set; }

        [JsonProperty(PName.DocumentType)]
        public string DocumentType { get; set; }
    }
}
