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
    public class CustomerSupplierData : BaseSupplierData
    {
        [JsonProperty(PName.SupplierName)]
        public string SupplierName { get; set; }

        [JsonProperty(PName.SupplierPrimUid)]
        public int SupplierId { get; set; }

        public bool Active { get; set; }

        [JsonProperty(PName.InputRequestPrimUid)]
        public int InputRequestId { get; set; }

        [JsonProperty(PName.DownloadStartDate)]
        public DateTime DownloadStartDate { get; set; }

        [JsonProperty(PName.LastStarted)]
        public DateTime LastStarted { get; set; }

        [JsonProperty(PName.NextPlannedRun)]
        public DateTime NextPlannedRun { get; set; }

        [JsonProperty(PName.LastStatusKey)]
        public string LastStatusKey { get; set; }

        public string Username { get; set; }
    }
}
