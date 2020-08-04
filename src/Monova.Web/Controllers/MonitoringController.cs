
using System;
using System.Collections.Generic;
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

        [NonAction]
        public async Task<object> GetMonitorClientModel(MVDMonitor monitor)
        {
            var url = string.Empty;
            var monitorStepRequest = await db.MonitorSteps.FirstOrDefaultAsync(x => x.MonitorId == monitor.Id && x.Type == MVDMonitorStepTypes.Request);

            var upTime = 0.00;
            var downTime = 0.00;
            var loadTime = 0.00;
            var totalMonitorTime = 0.00;
            var downTimePercent = 0.00;

            var loadTimes = new List<double>();
            var upTimes = new List<double>();

            if (monitorStepRequest != null)
            {

                var requestSettings = monitorStepRequest.SettingsAsRequest();
                if (requestSettings != null)
                    url = requestSettings.Url;
            }

            var week = DateTime.UtcNow.AddDays(-14);

            // son 14 gününde yapılan requestler
            var logs = await db.MonitorStepLogs
                                   .Where(x => x.MonitorStepId == monitorStepRequest.Id
                                   && x.StartDate >= week)
                                   .OrderByDescending(x => x.StartDate)
                                   .Take(50)
                                   .ToListAsync();
            // Loadtime sadece başarılı requestler üzerinden hesaplanıyor

            if (logs.Any(x => x.Status == MVDMonitorStepStatusType.Success))
            {
                loadTime = logs
                            .Where(x => x.Status == MVDMonitorStepStatusType.Success)
                            .Average(x => x.EndDate.Subtract(x.StartDate).TotalMilliseconds);

            }

            foreach (var log in logs)
            {
                totalMonitorTime += log.Interval;
                if (log.Status == MVDMonitorStepStatusType.Success)
                    loadTimes.Add(log.EndDate.Subtract(log.StartDate).TotalMilliseconds);
                if (log.Status == MVDMonitorStepStatusType.Fail)
                    downTime += log.Interval;

            }

            downTimePercent = 100 - (downTime / totalMonitorTime) * 100;

            return
                new
                {
                    monitor.Id,
                    monitor.LastCheckDate,
                    monitor.LoadTime,
                    monitor.Name,
                    monitor.TestStatus,
                    Url,
                    upTime,
                    upTimes,
                    downTime,
                    downTimePercent,
                    loadTime,
                    loadTimes,
                    totalMonitorTime
                };
        }

        [HttpGet]
        public async Task<IActionResult> Get(MVDMonitor monitor)
        {
            var list = await db.Monitors.Where(w => w.UserId.Equals(_userId)).ToListAsync();
            var clientList = new List<object>();

            foreach (var monitorItem in list)
                clientList.Add(await GetMonitorClientModel(monitorItem));

            return Success(data: list);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var monitor = await db.Monitors.Where(w => w.Id == id && w.UserId == _userId).ToListAsync();
            if (monitor == null)
                return Error("Monitor not found", code: 404);
            var clientList = new List<object>();

            foreach (var monitorItem in monitor)
                clientList.Add(await GetMonitorClientModel(monitorItem));

            return Success(data: monitor);
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
                Id = Guid.NewGuid(),
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

        public async Task<IActionResult> Put([FromBody] MVMMonitorSave value)
        {

            if (value.Id == Guid.Empty)
                return Error("You sent mistake parameters");

            var monitorCheck = await db.Monitors.AnyAsync(x => x.Id != value.Id && x.Name.Equals(value.Name) && x.UserId == _userId);
            if (monitorCheck)
                return Error("This project name is already in used. Please choose diffrent name");



            var monitor = await db.Monitors.FirstOrDefaultAsync(x => x.Id == value.Id && x.UserId == _userId);
            if (monitor == null)
                return Success("Monitor not found");

            monitor.Name = value.Name;
            monitor.UpdateTime = DateTime.UtcNow;

            #region Monitor Step Update
            var monitorStep = await db.MonitorSteps.FirstOrDefaultAsync(x => x.MonitorId == monitor.Id && x.Type == MVDMonitorStepTypes.Request);
            if (monitorStep != null)
            {
                var requestSettings = monitorStep.SettingsAsRequest() ?? new MVDSMonitorStepSettingsRequest();
                requestSettings.Url = value.Url;
                monitorStep.Settings = JsonConvert.SerializeObject(requestSettings);
            }

            var result = await db.SaveChangesAsync();
            if (result > 0)
                return Success("Monitoring Save successfully",
                new
                {
                    Id = monitor.Id
                });
            else
                return Error("something went wrong");


            #endregion


        }



    }
}