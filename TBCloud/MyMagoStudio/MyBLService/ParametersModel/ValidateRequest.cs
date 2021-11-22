using Newtonsoft.Json;
using System;

namespace MyBLService.ParametersModel
{
    public class ValidateRequest: BaseRequest
    {
        /// <summary>
        /// Document Mode
        /// </summary>
        [JsonProperty("docMode")]
        public int DocMode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// FromDate
        /// </summary>
        [JsonProperty("FromDate")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// ToDate
        /// </summary>
        [JsonProperty("ToDate")]
        public DateTime ToDate { get; set; }
    }
}
