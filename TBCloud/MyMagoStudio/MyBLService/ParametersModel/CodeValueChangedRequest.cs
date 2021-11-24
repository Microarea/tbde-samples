using MyBLService.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class CodeValueChangedRequest: BaseRequest
    {
        [JsonProperty("ContractCode")]
        public BaseModel<string> ContractCode { get; set; }
    }
}
