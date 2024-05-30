using JobSearchWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteUrl { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }

        public ICollection<Industry> Industries { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
