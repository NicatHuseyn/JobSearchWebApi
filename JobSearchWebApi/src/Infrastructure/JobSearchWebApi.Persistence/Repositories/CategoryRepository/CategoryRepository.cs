using JobSearchWebApi.Application.Repositories.CategroyRepository;
using JobSearchWebApi.Domain.Entities;
using JobSearchWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence.Repositories.CategoryRepository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepsoitory
    {
        public CategoryRepository(JobSearchDbContext context) : base(context)
        {
        }
    }
}
