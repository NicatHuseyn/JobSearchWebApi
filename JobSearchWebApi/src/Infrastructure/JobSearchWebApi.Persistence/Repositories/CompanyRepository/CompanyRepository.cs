using JobSearchWebApi.Application.Repositories.CompanyRepository;
using JobSearchWebApi.Domain.Entities;
using JobSearchWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence.Repositories.CompanyRepository
{
    public class CompanyRepository : Repository<Company>,ICompanyRepository
    {
        public CompanyRepository(JobSearchDbContext context) : base(context)
        {
        }
    }
}
