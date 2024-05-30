using JobSearchWebApi.Application.Repositories.JobRepository;
using JobSearchWebApi.Domain.Entities;
using JobSearchWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence.Repositories.JobRepository
{
    public class JobRepository : Repository<Job>,IJobRepository
    {
        public JobRepository(JobSearchDbContext context) : base(context)
        {
        }
    }
}
