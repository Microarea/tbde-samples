using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBLService.BaseModel;
using MyBLService.ParametersModel;
using System;
using System.Text.Json;
using Microarea.ERP.BillOfMaterials.Dbl;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MyBLService.Controllers
{
    // @@@@@supported starting by TbCloud v.1.4
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "MyBatch")]
    public class MyBatchBLController : ControllerBase
    {
        private readonly ILogger<MyDocBLController> _logger;


        //-----------------------------------------------------------------------------	
        public MyBatchBLController(ILogger<MyDocBLController> logger)
        {
            _logger = logger;
        }

        //-------------------------------------------------------------------------------
        [HttpPost("ControlsEnabled")]
        public ActionResult<BaseResponse> ControlsEnabled([FromBody] ControlsEnabledRequest request)
        {

            try
            {
                // to do: data preparation to populate model of results grid
                // returned via json into return value
                BaseResponse response = new BaseResponse();
                FilterBOM outFilter = new FilterBOM();

                if (request != null && request.All != null && request.Select != null &&
                        request.FromBOM != null && request.ToBOM != null)
                {
                    outFilter.All = request.All;
                    outFilter.Select = request.Select;
                    outFilter.FromBOM = request.FromBOM;
                    outFilter.ToBOM = request.ToBOM;
                    outFilter.Select.value = !outFilter.All.value;
                    if (outFilter.All.value)
                    {
                        outFilter.FromBOM.value = string.Empty;
                        outFilter.ToBOM.value = string.Empty;
                    }
                    outFilter.FromBOM.IsReadOnly = request.All.value;
                    outFilter.ToBOM.IsReadOnly = request.All.value;
                    response.ReturnValue = outFilter;
                }

                // variable to return result
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController ControlsEnabled exception  ", e);
            }
        }

        //-----------------------------------------------------------------------------
        [HttpPost("ValidateFilterDates")]
        public ActionResult<BaseResponse> ValidateFilterDates([FromBody] ValidateRequest request)
        {

            try
            {
                // to do: data preparation to populate model of results grid
                // returned via json into return value
                BaseResponse response = new BaseResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                //example: fromDate filter field must be less than toDate filter field
                //and send a boolean (TRUE means valid; FALSE means invalid) back to tbServer
                response.ReturnValue = request.FromDate < request.ToDate;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController ValidateFilterDates exception  ", e);
            }
        }

        //-----------------------------------------------------------------------------
        [HttpPost("AllBOM_ValueChanged")]
        public ActionResult<BaseResponse> AllBOM_ValueChanged([FromBody] ControlsEnabledRequest request)
        {

            try
            {
                // to do: data preparation to populate model of results grid
                // returned via json into return value
                BaseResponse response = new BaseResponse();
                if (request == null || request.All == null || request.Select == null ||
                    request.FromBOM == null || request.ToBOM == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }

                //in this example we imagine to manage a filter all/select/from/to
                //if all = true, then select = false and from/to must be readonly and containing empty values
                //if select = true, then all = false and from/to must be editable and containing empty values
                FilterBOM outFilter = new FilterBOM();
                outFilter.All = request.All;
                outFilter.Select = request.Select;
                outFilter.FromBOM = request.FromBOM;
                outFilter.ToBOM = request.ToBOM;
                outFilter.Select.value = !outFilter.All.value;
                if (outFilter.All.value)
                {
                    outFilter.FromBOM.value = string.Empty;
                    outFilter.ToBOM.value = string.Empty;
                }
                outFilter.FromBOM.IsReadOnly = request.All.value;
                outFilter.ToBOM.IsReadOnly = request.All.value;
                response.ReturnValue = outFilter;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController AllBOM_ValueChanged exception  ", e);
            }
        }

        [HttpPost("ExtractData")]
        public ActionResult<ExtractDataResponse> ExtractData([FromBody] ExtractDataRequest request)
        {

            try
            {
                // to do: data preparation to populate model of results grid
                // returned via json into return value
                //manage your filters here and make a query that populate the outRows structure
                //
                ExtractDataResponse response = new ExtractDataResponse();
                ////use this if you serialize data with value mode
                //List<MABillOfMaterialsRow> outRows = new List<MABillOfMaterialsRow>();
                ////first row example
                //MABillOfMaterialsRow row = new MABillOfMaterialsRow();
                //MABillOfMaterialsExt rowExt = new MABillOfMaterialsExt();
                //row.MA_BillOfMaterials_Extended = rowExt;
                //row.BOM = "BEVDIS";
                //row.Description = "Bevanda dissetante (from ExtractData)";
                //row.UoM = "lt";
                //row.Notes = "Inserted automatically (from ExtractData)";
                //row.Disabled = "0";
                //rowExt.BOM = "BEVDIS";
                //rowExt.ActivatedDate = DateTime.Now;
                //rowExt.Selected = false;
                //outRows.Add(row);
                ////second row example
                //row = new MABillOfMaterialsRow();
                //rowExt = new MABillOfMaterialsExt();
                //row.MA_BillOfMaterials_Extended = rowExt;
                //row.BOM = "BICICONF";
                //row.Description = "Bicicletta (from ExtractData)";
                //row.UoM = "nr";
                //row.Notes = "Inserted automatically (from ExtractData)";
                //row.Disabled = "1";
                //rowExt.BOM = "BICICONF";
                //rowExt.ActivatedDate = DateTime.Now;
                //rowExt.Selected = false;
                //outRows.Add(row);

                //example - imagine that ExtractData you have to populate the grid with the extraction data
                //after you have queried your db applying the filters that you receveid in the request
                //and then you have to make the key readOnly
                //in our example the key is composed by BOM field
                //use this if you serialize data with FullDataObj mode
                List<MABillOfMaterialsRowFullData> outRows = new List<MABillOfMaterialsRowFullData>();
                //first row example
                MABillOfMaterialsRowFullData row = new MABillOfMaterialsRowFullData();
                MABillOfMaterialsExtFullData rowExt = new MABillOfMaterialsExtFullData();
                row.MA_BillOfMaterials_Extended = rowExt;
                row.BOM.value = "BEVDIS";
                row.BOM.IsReadOnly = true;
                row.Description.value = "Bevanda dissetante (from ExtractData)";
                row.UoM.value = "lt";
                row.Notes.value = "Inserted automatically (from ExtractData)";
                row.Disabled.value = false;
                rowExt.BOM.value = "BEVDIS";
                rowExt.ActivatedDate.value = DateTime.Now;
                rowExt.Selected.value = false;
                outRows.Add(row);
                //second row example
                row = new MABillOfMaterialsRowFullData();
                rowExt = new MABillOfMaterialsExtFullData();
                row.MA_BillOfMaterials_Extended = rowExt;
                row.BOM.value = "BICICONF";
                row.BOM.IsReadOnly = true;
                row.Description.value = "Bicicletta (from ExtractData)";
                row.UoM.value = "nr";
                row.Notes.value = "Inserted automatically (from ExtractData)";
                row.Disabled.value = true;
                rowExt.BOM.value = "BICICONF";
                rowExt.ActivatedDate.value = DateTime.Now;
                rowExt.Selected.value = false;
                outRows.Add(row);

                //set returnValue on response
                response.ReturnValue = outRows;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController ExtractData exception  ", e);
            }
        }

        [HttpPost("BatchExecute")]
        public ActionResult<BatchExecuteRequestResponse> BatchExecute([FromBody] BatchExecuteRequest request)
        {

            try
            {
                // to do: batch business logic code. At the end,
                // response return value will contain if batch ended succesfully or with errors
                // ErrorMessage and diagnostic elements will pupulate batch Diagnostic compononent
                //example - imagine that BatchExecute you have to populate the grid with the extraction data
                //after you have queried your db and then you have to make readOnly all fields
                BatchExecuteRequestResponse response = new BatchExecuteRequestResponse();
                if (request == null || request.MyParamIn == null || request.MyParamIn.Count == 0)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }

                //populate here your structures
                List<MABillOfMaterialsRowFullData> outList = new List<MABillOfMaterialsRowFullData>();
                foreach(var item in request.MyParamIn)
                {
                    outList.Add(item);
                    item.BOM.IsReadOnly = true;
                    item.Description.IsReadOnly = true;
                    item.Disabled.IsReadOnly = true;
                    item.Notes.IsReadOnly = true;
                    item.UoM.IsReadOnly = true;
                    item.MA_BillOfMaterials_Extended.BOM.value = item.BOM.value;
                    item.MA_BillOfMaterials_Extended.BOM.IsReadOnly = true;
                    item.MA_BillOfMaterials_Extended.ActivatedDate.IsReadOnly = true;
                    item.MA_BillOfMaterials_Extended.Selected.IsReadOnly = true;
                }
                response.ReturnValue = outList;
                
                response.Success = true;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController BatchExecute exception  ", e);
            }
        }

        [HttpPost("BE_RowChanged")]
        public ActionResult<BaseResponse> BE_RowChanged([FromBody] BEOneRowRequest request)
        {

            try
            {
                // to do: batch business logic code. At the end,
                // response return value will contain if batch ended succesfully or with errors
                // ErrorMessage and diagnostic elements will pupulate batch Diagnostic compononent
                //example - imagine that RowChanged you have to compile automatically the Notes field
                BaseResponse response = new BaseResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                if (request.MyParamIn.Count != 1)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("The request must contains only one row");
                    return new OkObjectResult(response);
                }
                //populate here your structures
                MABillOfMaterialsRowFullData outItem = new MABillOfMaterialsRowFullData();
                outItem = request.MyParamIn[0];
                outItem.Notes.value = $"{outItem.Notes.value} (BE_RowChanged is executed)";
                response.ReturnValue = outItem;
                response.Success = true;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController BE_RowChanged exception  ", e);
            }
        }

        [HttpPost("Description_ValueChanged")]
        public ActionResult<BaseResponse> Description_ValueChanged([FromBody] BEOneRowRequest request)
        {

            try
            {
                // to do: batch business logic code. At the end,
                // response return value will contain if batch ended succesfully or with errors
                // ErrorMessage and diagnostic elements will pupulate batch Diagnostic compononent
                //example - imagine that description changed you modify Notes field and UoM field becomes readonly
                BaseResponse response = new BaseResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                if (request.MyParamIn.Count != 1)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("The request must contains only one row");
                    return new OkObjectResult(response);
                }
                
                //populate here your structures
                MABillOfMaterialsRowFullData outItem = new MABillOfMaterialsRowFullData();
                outItem = request.MyParamIn[0];
                outItem.Notes.value = $"{outItem.Notes.value} (Description_ValueChanged is executed)";
                response.ReturnValue = outItem;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController Description_ValueChanged exception  ", e);
            }
        }

        [HttpGet]
        //-----------------------------------------------------------------------------	
        public IActionResult Get()
        {
            return Content("Welcome to MyMagoStudio Batch Sample Controller");
        }

        [HttpGet("assemblyversion")]
        //-----------------------------------------------------------------------------	
        public IActionResult ApiAssemblyVersion()
        {
            Version ver = new Version(1, 0);
            return new JsonResult(new { Version = ver.ToString() });
        }
    }
}
