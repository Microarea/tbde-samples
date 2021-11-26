using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class ExtraTransactingRequest: BaseRequest
    {
        /// <summary>
        /// Document FormMode
        /// </summary>
        [JsonProperty("formMode")]
        public int FormMode { get; set; } = -1;
    }
}
