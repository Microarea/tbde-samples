using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class ErrorMessage
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorMessage InnerErrorMessage { get; set; }

        public ErrorMessage(string text)
        {
            Text = text;
        }
    }
}
