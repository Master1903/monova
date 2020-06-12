
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Monova.Web.Controllers
{

    [Authorize] // Meaning, inside using this controller  via all views 
    public class MonitoringController : Controller
    {

        // [Authorize] //This attr will show only for authorized users  
        public IActionResult Index()
        {
            return View();
        }

    }
}