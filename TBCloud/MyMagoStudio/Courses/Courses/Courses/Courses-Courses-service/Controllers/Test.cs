using Microsoft.AspNetCore.Mvc;
using Microarea.Tbf.Model.MyMagoStudioBase;

namespace Courses.Courses.Controllers
{
    [ApiController]
    [Route("Courses-Courses-service/[controller]")]
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