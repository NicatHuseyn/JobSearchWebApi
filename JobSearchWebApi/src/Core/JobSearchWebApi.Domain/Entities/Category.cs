using JobSearchWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string Icon { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
