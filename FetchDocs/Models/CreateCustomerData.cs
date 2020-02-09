//////////////////////////////////////////////////////////////////////////////
//  
//      Author: Max Schwaibold
//      Date: 09.02.2020
//
//////////////////////////////////////////////////////////////////////////////

using Newtonsoft.Json;

namespace FetchDocs.Models
{
    public class CreateCustomerData
    {
        [JsonProperty(PName.PrimUid)]
        public int Id { get; set; }

        [JsonProperty(PName.CustomerSecret)]
        public string Secret { get; set; }

        [JsonProperty(PName.AccessToken)]
        public string AccessToken { get; set; }
    }
}
