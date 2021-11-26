using MyBLService.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class TransactionValidationRequest: BaseRequest
    {
        [JsonProperty("Description")]
        public BaseModel<string> Description { get; set; }

        [JsonProperty("Disabled")]
        public BaseModel<bool> Disabled { get; set; }
    }
}
