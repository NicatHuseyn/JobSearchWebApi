using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CategoryQuery.GetAllCategory
{
    public class GetAllCategoryQueryRequest:IRequest<List<GetAllCategoryQueryResponse>>
    {
    }
}
