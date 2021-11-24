using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBLService.BaseModel;
using MyBLService.ParametersModel;
using System;
using System.Threading.Tasks;

namespace MyBLService.Controllers
{
    // @@@@@supported starting by TbCloud v.1.3
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "MyDocBL")]
    public class MyDocBLController : ControllerBase
    {
        private readonly ILogger<MyDocBLController> _logger;

        //-----------------------------------------------------------------------------	
        public MyDocBLController(ILogger<MyDocBLController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //-----------------------------------------------------------------------------	
        public IActionResult Get()
        {
            return Content("Welcome to MyMagoStudio Data Entry Sample Controller");
        }

        [HttpPost("Validate")]
        public ActionResult<ValidateResponse> Validate([FromBody] ValidateRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                response.ReturnValue = true;
                response.Success = true;
                if (request.DocMode == 2 /*FormModeType.New*/ || request.DocMode == 3/*FormModeType.Edit*/)
                {
                    if (request.Code != null && request.Code.StartsWith("A"))
                    {
                        response.ErrorMessage = new ErrorMessage($"Code {request.Code} cannot start with A!!!");
                        response.ReturnValue = false;
                    }
                }

                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL Validating exception  ", e);
            }
        }

        [HttpPost("ControlsEnabled")]
        public ActionResult<BaseResponse> ControlsEnabled([FromBody] ControlsEnabledRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.Description == null || request.Notes == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.Description = request.Description;
                tMaster.Notes = request.Notes;
                
                if (request.FormMode == 2 /*FormModeType.New*/)
                {
                    //example: imagine that New FormMode you have to disabled
                    //Notes field and enabled Description field
                    tMaster.Notes.value = "new notes";
                    tMaster.Notes = request.Notes;
                    tMaster.Notes.IsReadOnly = true;
                    tMaster.Description.value = "new description";
                    tMaster.Description = request.Description;
                    tMaster.Description.IsReadOnly = false;
                }

                if (request.FormMode == 3 /*FormModeType.Edit*/)
                {
                    //example: imagine that Edit FormMode you have to enabled
                    //Notes field and disabled Description field
                    tMaster.Notes = request.Notes;
                    tMaster.Notes.IsReadOnly = false;
                    tMaster.Description = request.Description;
                    tMaster.Description.IsReadOnly = true;
                }
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL ControlsEnabled exception  ", e);
            }
        }

        [HttpPost("Code_ValueChanged")]
        public ActionResult<BaseResponse> Code_ValueChanged([FromBody] CodeValueChangedRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.ContractCode == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.ContractCode = request.ContractCode;
                
                //imagine that when ContractCode = '0000' or '9999' you have to
                //disable it
                if 
                    (
                        tMaster.ContractCode.value.CompareTo("0000") == 0 ||
                        tMaster.ContractCode.value.CompareTo("9999") == 0
                    )
                {
                    tMaster.Disabled = new BaseModel<bool>();
                    tMaster.Disabled.value = true;
                }
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL Code_ValueChanged exception  ", e);
            }
        }
        
        [HttpPost("Btn_Clicked")]
        public ActionResult<BaseResponse> Btn_Clicked([FromBody] CodeValueChangedRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.ContractCode == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.ContractCode = request.ContractCode;
                if (string.IsNullOrEmpty(tMaster.ContractCode.value))
                {
                    tMaster.Notes = new BaseModel<string>();
                    tMaster.Notes.value = "inserted automatically from Btn_Clicked api";
                    tMaster.Notes.IsReadOnly = false;
                }
                    
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL Code_ValueChanged exception  ", e);
            }
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
