using JobSearchWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Domain.Entities
{
    public class Job:BaseEntity
    {
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobRequierment { get; set; }
        public bool isNew { get; set; }
        public int ViewCount { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }
     
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
