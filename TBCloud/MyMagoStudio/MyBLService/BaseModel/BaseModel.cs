using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.BaseModel
{
    public class BaseModel<T>
    {
        [JsonProperty("value")]
        public T value { get; set; }
        [JsonProperty("IsReadOnly")]
        public bool IsReadOnly { get; set; }
        [JsonProperty("IsHide")]
        public bool IsHide { get; set; }
    }
}
