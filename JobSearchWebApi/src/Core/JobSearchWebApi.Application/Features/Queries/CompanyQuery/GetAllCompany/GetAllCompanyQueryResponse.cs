using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CompanyQuery.GetAllCompany
{
    public class GetAllCompanyQueryResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteUrl { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
