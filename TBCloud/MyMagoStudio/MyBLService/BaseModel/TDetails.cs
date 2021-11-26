using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.BaseModel
{
    public class TDetails
    {
        [JsonProperty("ContractCode", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> ContractCode { get; set; }
        [JsonProperty("Row", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<int> Row { get; set; }
        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> Description { get; set; }
        [JsonProperty("ActivationDate", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<int> ActivationDate { get; set; }
        [JsonProperty("Valid", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<bool> Valid { get; set; }
        [JsonProperty("DateActivation", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<DateTime> DateActivation { get; set; }
        [JsonProperty("AuxDescription", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> AuxDescription { get; set; }
    }
}
