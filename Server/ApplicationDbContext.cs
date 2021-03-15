using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTimesheets.Shared.Entities;

namespace OpenTimesheets.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WorkShift> WorkShifts { get; set; }

        //public DbSet<ProjAlloc> ProjAllocs { get; set; } //later need lookup tbl?
    }
}
