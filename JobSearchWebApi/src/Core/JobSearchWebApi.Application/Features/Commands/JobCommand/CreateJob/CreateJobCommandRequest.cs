using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.CreateJob
{
    public class CreateJobCommandRequest:IRequest<CreateJobCommandResponse>
    {
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobRequierment { get; set; }
        public bool isNew { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
    }
}
