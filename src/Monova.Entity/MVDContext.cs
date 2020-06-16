using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Monova.Entity
{
    public class MVDContext : IdentityDbContext<MVDUser, IdentityRole<Guid>, Guid> // Contextimizi IdentityDbContext den türettik. IdentityUser yani bizim MVDUser daki Id alanı microsoft default olarak text tutuyor. Biz MVDUser daki Id alanını Guid olarak yaptığımızdan dolayı (public class MVDUser : IdentityUser<Guid>) Onunla ilişkili olan IdentityRole Tablosunudaki ilişkiyide Guid olarak yaptık(IdentityDbContext<MVDUser, IdentityRole<Guid>, Guid>)
    {
        public MVDContext(DbContextOptions<MVDContext> options) : base(options)
        {
        }
        public DbSet<MVDMonitor> Monitors { get; set; }
        public DbSet<MVDMonitorStep> MonitorSteps { get; set; }
        public DbSet<MVDMonitorStepLog> MonitorStepLogs { get; set; }



    }
}

