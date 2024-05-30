using HotelierProject.Persistence;
using JobSearchWebApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<JobSearchDbContext>
    {
        public JobSearchDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<JobSearchDbContext> builder = new DbContextOptionsBuilder<JobSearchDbContext>();
            builder.UseSqlServer(Configuration.ConnectionString);
            return new JobSearchDbContext(builder.Options);
        }
    }
}
