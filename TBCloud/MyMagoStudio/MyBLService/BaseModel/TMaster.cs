using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.BaseModel
{
    public class TMaster
    {
        public TMaster( )
        {
            
        }
        
        [JsonProperty("ContractCode", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> ContractCode { get; set; }
        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> Description { get; set; }
        [JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> Notes { get; set; }
        [JsonProperty("Disabled", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<bool> Disabled { get; set; }
        [JsonProperty("LocalAuxNotes", NullValueHandling = NullValueHandling.Ignore)]
        public BaseModel<string> LocalAuxNotes { get; set; }
    }

    public class TMasterLight
    {
        [JsonProperty("LocalAuxNotes")]
        public string LocalAuxNotes { get; set; }
    }
}
