using MyBLService.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.ParametersModel
{
    public class DataLoadedRequest: BaseRequest
    {
        //add your properties needed here


        [JsonProperty("Description")]
        public BaseModel<string> Description { get; set; }
    }
}
