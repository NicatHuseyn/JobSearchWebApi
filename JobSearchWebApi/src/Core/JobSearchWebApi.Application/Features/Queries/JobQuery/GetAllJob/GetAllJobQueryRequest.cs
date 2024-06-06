using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.JobQuery.GetAllJob
{
    public class GetAllJobQueryRequest:IRequest<List<GetAllJobQueryResponse>>
    {

    }
}
