using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Monova.Entity
{
    public class MVDContext : IdentityDbContext<MVDUser>
    {
        public MVDContext(DbContextOptions<MVDContext> options) : base(options)
        {
        }
    }
}
