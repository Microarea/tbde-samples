using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet("assemblyversion")]
        //-----------------------------------------------------------------------------	
        public IActionResult ApiAssemblyVersion()
        {
            Version ver = new Version(1, 0);
            return new JsonResult(new { Version = ver.ToString() });
        }
    }
}
