﻿using Newtonsoft.Json;
using MyBLService.BaseModel;
using System.Collections.Generic;

namespace MyBLService.ParametersModel
{
    public class BatchExecuteRequest: BaseRequest
    {
        /// <summary>
        /// MyParamIn
        /// </summary>
        [JsonProperty("MyParamIn")]
        public List<MABillOfMaterialsRowFullData> MyParamIn { get; set; }
    }
}
