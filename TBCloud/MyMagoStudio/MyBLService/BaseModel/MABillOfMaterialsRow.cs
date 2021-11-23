using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microarea.ERP.BillOfMaterials.Dbl;
using Newtonsoft.Json;

namespace MyBLService.BaseModel
{
    /// <summary>
    /// use this class in case of you aren't using FullDataObj serialization mode
    /// </summary>
    public class MABillOfMaterialsRow: MA_BillOfMaterials
    {
        [JsonProperty("MA_BillOfMaterials_Extended")]
        public MABillOfMaterialsExt MA_BillOfMaterials_Extended { get; set; }
    }

    /// <summary>
    /// use this class in case of you aren't using FullDataObj serialization mode
    /// </summary>
    public class MABillOfMaterialsExt
    {
        [JsonProperty("BOM")]
        public string BOM { get; set; }
        [JsonProperty("Selected")]
        public bool Selected { get; set; }
        [JsonProperty("ActivatedDate")]
        public DateTime ActivatedDate { get; set; }

    }

    /// <summary>
    /// use this class in case of you are using FullDataObj serialization mode
    /// </summary>
    public class MABillOfMaterialsRowFullData
    {
        //public constructor
        public MABillOfMaterialsRowFullData()
        {
            this.BOM = new BaseModel<string>();
            this.Description = new BaseModel<string>();
            this.UoM = new BaseModel<string>();
            this.Notes = new BaseModel<string>();
            this.Disabled = new BaseModel<bool>();
        }

        
        [JsonProperty("BOM")]
        public BaseModel<string> BOM { get; set; }
        [JsonProperty("Description")]
        public BaseModel<string> Description { get; set; }
        [JsonProperty("UoM")]
        public BaseModel<string> UoM { get; set; }
        [JsonProperty("Notes")]
        public BaseModel<string> Notes { get; set; }
        [JsonProperty("Disabled")]
        public BaseModel<bool> Disabled { get; set; }
        [JsonProperty("MA_BillOfMaterials_Extended")]
        public MABillOfMaterialsExtFullData MA_BillOfMaterials_Extended { get; set; }
    }

    /// <summary>
    /// use this class in case of you are using FullDataObj serialization mode
    /// </summary>
    public class MABillOfMaterialsExtFullData
    {
        //public constructor
        public MABillOfMaterialsExtFullData()
        {
            this.BOM = new BaseModel<string>();
            this.Selected = new BaseModel<bool>();
            this.ActivatedDate = new BaseModel<DateTime>();
        }

        [JsonProperty("BOM")]
        public BaseModel<string> BOM { get; set; }
        [JsonProperty("Selected")]
        public BaseModel<bool> Selected { get; set; }
        [JsonProperty("ActivatedDate")]
        public BaseModel<DateTime> ActivatedDate { get; set; }

    }
}
