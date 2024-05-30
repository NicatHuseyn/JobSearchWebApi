using JobSearchWebApi.Application.Repositories.IndustryRepository;
using JobSearchWebApi.Domain.Entities;
using JobSearchWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence.Repositories.IndustryRepository
{
    public class IndustryRepository : Repository<Industry>,IIndustryRepository
    {
        public IndustryRepository(JobSearchDbContext context) : base(context)
        {
        }
    }
}
