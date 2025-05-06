using Microsoft.AspNetCore.Mvc;
using Microarea.Tbf.Model.MyMagoStudioBase;

namespace OttieniToken.MOToken.Controllers
{
    [ApiController]
    [Route("OttieniToken-MOToken-service/[controller]")]
    [ApiExplorerSettings(GroupName = "Test")]
    public class Test : Controller
    {
        /// <summary>
        /// Test for is alive
        /// </summary>
        /// <returns>true</returns>
        [HttpGet]
        [Route("IsAlive")]
        public IActionResult IsAlive()
        {
            return new SuccessResult(true);
        }
    }
}