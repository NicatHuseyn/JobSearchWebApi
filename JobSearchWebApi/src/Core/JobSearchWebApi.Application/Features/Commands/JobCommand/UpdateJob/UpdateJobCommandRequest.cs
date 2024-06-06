using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.UpdateJob
{
    public class UpdateJobCommandRequest:IRequest<UpdateJobCommandResponse>
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobRequierment { get; set; }
        public bool isNew { get; set; }
    }
}
