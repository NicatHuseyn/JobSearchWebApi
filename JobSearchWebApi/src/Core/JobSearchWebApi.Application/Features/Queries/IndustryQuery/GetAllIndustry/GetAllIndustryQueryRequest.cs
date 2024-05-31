using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.IndustryQuery.GetAllIndustry
{
    public class GetAllIndustryQueryRequest:IRequest<List<GetAllIndustryQueryReponse>>
    {
    }
}
