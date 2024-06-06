using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.RemoveJob
{
    public class RemoveJobCommandRequest:IRequest<RemoveJobCommandResponse>
    {
        public int Id { get; set; }
    }
}
