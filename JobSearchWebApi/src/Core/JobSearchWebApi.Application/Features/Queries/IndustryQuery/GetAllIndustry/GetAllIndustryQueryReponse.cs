using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.IndustryQuery.GetAllIndustry
{
    public class GetAllIndustryQueryReponse
    {
        public int Id { get; set; }
        public string IndustryName { get; set; }
        public string Icon { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
