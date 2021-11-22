using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBLService.BaseModel
{
    public class FilterBOM
    {
        public BaseModel<bool> All { get; set; }
        public BaseModel<bool> Select { get; set; }
        public BaseModel<string> FromBOM { get; set; }
        public BaseModel<string> ToBOM { get; set; }
    }
}
