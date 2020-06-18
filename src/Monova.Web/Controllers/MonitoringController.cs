
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post(object value)
        {
            return Forbid();
            // return Json(
            //  new
            //  {
            //      Success = true,
            //      Message = value
            //  });
        }



    }
}