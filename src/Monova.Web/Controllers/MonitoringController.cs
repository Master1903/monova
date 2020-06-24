
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monova.Entity;

namespace Monova.Web.Controllers
{

    // [Authorize] // Meaning, inside using this controller  via all views 
    public class MonitoringController : ApiController
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Json(
                new
                {
                    Success = true,
                    Message = "Hi There"
                });

        }

        [HttpPost]
        public IActionResult Post([FromBody] MVDMonitor value)
        {
            return Success("Monitoring Save successfully");

        }



    }
}