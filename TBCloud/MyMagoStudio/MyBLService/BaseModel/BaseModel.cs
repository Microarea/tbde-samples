using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.BaseModel
{
    /// <summary>
    /// This class is usefull in case you serialize data with "FullDataObj"
    /// that means you need also isReadOnly and isHide in addition to the value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseModel<T>
    {
        [JsonProperty("value")]
        public T value { get; set; }
        [JsonProperty("isReadOnly")]
        public bool IsReadOnly { get; set; } = false;
        [JsonProperty("isHide")]
        public bool IsHide { get; set; } = false;
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; } = false;
    }
}
