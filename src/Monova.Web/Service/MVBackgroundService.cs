using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monova.Entity;

namespace Monova.Web
{
    public class MVBackgroundService : IHostedService, IDisposable
    {
        public IServiceProvider _services { get; }
        private CancellationToken _token;

        public MVBackgroundService(IServiceProvider services)
        {
            _services = services;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _token = cancellationToken;
            DoWork();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async void DoWork()
        {
            while (true)
            {
                using (var scope = _services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<MVDContext>();

                    // hiç işlem yapmadığım 20 adet step
                    var steps = await db.MonitorSteps
                                        .Where(x => x.Type == MVDMonitorStepTypes.Request
                                        && x.Status != MVDMonitorStepStatusType.Processing)
                                        .Take(20)
                                        .ToListAsync();

                    foreach (var step in steps)
                    {
                        var settings = step.SettingsAsRequest();
                        if (string.IsNullOrEmpty(settings.Url))

                        {
                            //yaptığım her site işlemi için log yaz.
                            var log = new MVDMonitorStepLog
                            {
                                MonitorId = step.MonitorId,
                                MonitorStepId = step.Id,
                                StartDate = DateTime.UtcNow,
                                Interval = step.Interval,
                                Status = MVDMonitorStepStatusType.Processing
                            };
                            db.Add(log);

                            // Bu servis cancel edildiği zaman, asenkron işlemlerin bildirilmesini sağlamak için, token parametresi geçtim.
                            await db.SaveChangesAsync(_token);

                            try
                            {
                                //requesti at.
                                var client = new HttpClient();
                                client.Timeout = TimeSpan.FromSeconds(15);
                                var result = await client.GetAsync(settings.Url, _token);
                                if (result.IsSuccessStatusCode)
                                    log.Status = MVDMonitorStepStatusType.Success;
                                else
                                    log.Status = MVDMonitorStepStatusType.Fail;

                            }
                            catch (Exception ex)
                            {

                                log.Log = ex.Message;
                                log.Status = MVDMonitorStepStatusType.Error;
                            }
                            finally
                            {
                                log.EndDate = DateTime.UtcNow;
                            }

                            if (log.Status == MVDMonitorStepStatusType.Success)
                                step.Status = MVDMonitorStepStatusType.Success;
                            else if (log.Status == MVDMonitorStepStatusType.Error)
                                step.Status = MVDMonitorStepStatusType.Error;
                            else
                                step.Status = MVDMonitorStepStatusType.Fail;
                        }

                        step.LastCheckDate = DateTime.UtcNow;

                        await db.SaveChangesAsync(_token);
                    }

                }

                await Task.Delay(500, _token);
            }
        }
        public void Dispose()
        {
            
        }

    }

}