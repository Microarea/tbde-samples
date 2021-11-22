using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBLService.BaseModel;
using MyBLService.ParametersModel;
using System;

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
        public ActionResult<BaseResponse> ControlsEnabled([FromBody] FiltersEnabledRequest request)
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
                if (request != null)
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
        public ActionResult<BaseResponse> AllBOM_ValueChanged([FromBody] FiltersEnabledRequest request)
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
                ExtractDataResponse response = new ExtractDataResponse();
                // variable to return result grid data
                // response.ReturnValue = new { xxx };
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
                BatchExecuteRequestResponse response = new BatchExecuteRequestResponse();
                response.ReturnValue = true;
                // variable to return batch error
                // response.ErrorMessage = null;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController BatchExecute exception  ", e);
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
