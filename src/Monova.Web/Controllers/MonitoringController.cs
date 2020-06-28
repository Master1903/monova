
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monova.Entity;
using Newtonsoft.Json;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var monitor = await db.Monitors.FirstOrDefaultAsync(w => w.Id == id && w.UserId == _userId);
            if (monitor == null)
                return Error("Monitor not found", code: 404);


            return Success(null, monitor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MVMMonitorSave value)
        {
            if (string.IsNullOrEmpty(value.Name))
                return Error("Name is required");


            var monitorObject = new MVDMonitor
            {
                Id = Guid.NewGuid(),
                Name = value.Name,
                CreatedDate = DateTime.UtcNow,
                UserId = _userId
            };
            db.Add(monitorObject);

            var monitorStepData = new MVDSMonitorStepSettingsRequest
            {
                Url = value.Url

            };
            var monitorStep = new MVDMonitorStep
            {
                // Id = Guid.NewGuid(),
                MonitorId = monitorObject.Id,
                Type = MVDMonitorStepTypes.Request,
                Settings = JsonConvert.SerializeObject(monitorStepData) //gelen stringi JSON' a çevir
            };
            db.MonitorSteps.Add(monitorStep);

            var result = await db.SaveChangesAsync();
            if (result > 0)
                return Success("Monitoring Save successfully",
                new
                {
                    Id = monitorObject.Id
                });
            else
                return Error("something went wrong");

        }





    }
}