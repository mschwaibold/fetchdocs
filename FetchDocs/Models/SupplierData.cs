//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

using Newtonsoft.Json;
using System;

namespace FetchDocs.Models
{
    public class SupplierData : BaseSupplierData
    {
        public string Name { get; set; }

        public DateTime Created { get; set; }

        [JsonProperty(PName.SupplierLoginUrl)]
        public string SupplierLoginUrl { get; set; }

        [JsonProperty(PName.QuickFeedbackSupport)]
        public bool QuickFeedbackSupport { get; set; }
    }
}
