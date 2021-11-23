using MyBLService.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class BEOneRowRequest: BaseRequest
    {
        /// <summary>
        /// MyParamIn
        /// </summary>
        [JsonProperty("MyParamIn")]
        public List<MABillOfMaterialsRowFullData> MyParamIn { get; set; }
    }
}
