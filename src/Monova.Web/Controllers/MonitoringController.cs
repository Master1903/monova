
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monova.Entity;

namespace Monova.Web.Controllers
{

    // [Authorize] // Meaning, inside using this controller  via all views 
    public class MonitoringController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await db.Monitors.ToListAsync();
            return Success(null, list);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MVDMonitor value)
        {

            var dataObject = new MVDMonitor
            {
                Name = value.Name,
                CreatedDate = DateTime.UtcNow
            };

            db.Add(value);
            var result = await db.SaveChangesAsync();
            if (result > 0)
                return Success("Monitoring Save successfully",
                new
                {
                    Id = dataObject.Id
                });
            else
                return Error("something went wrong");

        }



    }
}