using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.JobQuery.GetByIdJob
{
    public class GetByIdJobQueryRequest:IRequest<GetByIdJobQueryResponse>
    {
        public int Id { get; set; }
    }
}
