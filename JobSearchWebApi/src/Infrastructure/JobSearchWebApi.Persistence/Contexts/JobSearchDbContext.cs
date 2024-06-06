using JobSearchWebApi.Domain.Entities;
using JobSearchWebApi.Domain.Entities.Common;
using JobSearchWebApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence.Contexts
{
    public class JobSearchDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public JobSearchDbContext(DbContextOptions<JobSearchDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Industry> Industries { get; set; }
        public DbSet<Job> Jobs { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateData = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _=> DateTime.UtcNow
                };
            }


            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
