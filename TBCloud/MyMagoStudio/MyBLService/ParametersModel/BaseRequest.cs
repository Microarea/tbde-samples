using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class BaseRequest
    {
        /// <summary>
        /// RequestId
        /// </summary>
        [JsonProperty("requestId")]
        public object RequestId { get; set; }
        /// <summary>
        /// OperationDate
        /// </summary>
        [JsonProperty("operationDate")]
        public DateTime OperationDate { get; set; }
    }
}
