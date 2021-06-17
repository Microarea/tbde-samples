
using Newtonsoft.Json;

namespace MyBLService.ParametersModel
{
    public class ExtractDataResponse
    {
        /// <summary>
        /// ReturnValue
        /// </summary>
        [JsonProperty("retVal")]
        public object ReturnValue { get; set; }
        /// <summary>
        /// Success
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; } = false;
        /// <summary>
        /// ErrorMessage
        /// </summary>
        [JsonProperty("errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorMessage ErrorMessage { get; set; }
     }
}
