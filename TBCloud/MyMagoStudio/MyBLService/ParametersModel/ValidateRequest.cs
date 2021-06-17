using Newtonsoft.Json;
using System;

namespace MyBLService.ParametersModel
{
    public class ValidateRequest
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

         /// <summary>
        /// Document Mode
        /// </summary>
        [JsonProperty("docMode")]
        public int DocMode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
