using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microarea.Generic.CoreTypes;
using Newtonsoft.Json;
using MyBLService.BaseModel;

namespace MyBLService.ParametersModel
{
    public class FiltersEnabledRequest : BaseRequest 
    {
        /// <summary>
        /// All
        /// </summary>
        [JsonProperty("All")]
        public BaseModel<bool> All { get; set; }
        /// <summary>
        /// Select
        /// </summary>
        [JsonProperty("Select")]
        public BaseModel<bool> Select { get; set; }
        /// <summary>
        /// FromBOM
        /// </summary>
        [JsonProperty("FromBOM")]
        public BaseModel<string> FromBOM { get; set; }
        /// <summary>
        /// ToBOM
        /// </summary>
        [JsonProperty("ToBOM")]
        public BaseModel<string> ToBOM { get; set; }
    }
}
