using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CategoryQuery.GetByIdCategory
{
    public class GetByIdCategoryQueryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
