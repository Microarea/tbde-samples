using Newtonsoft.Json;
using System;

namespace MyBLService.ParametersModel
{
    public class BatchExecuteRequest
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
