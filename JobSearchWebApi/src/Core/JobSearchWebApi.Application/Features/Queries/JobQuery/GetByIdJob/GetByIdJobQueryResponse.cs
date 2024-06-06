using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.JobQuery.GetByIdJob
{
    public class GetByIdJobQueryResponse
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobRequierment { get; set; }
        public bool isNew { get; set; }
        public int ViewCount { get; set; }

        public DateTime CreateData { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
