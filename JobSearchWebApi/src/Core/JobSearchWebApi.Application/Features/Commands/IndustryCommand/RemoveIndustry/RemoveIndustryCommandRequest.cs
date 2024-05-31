using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.IndustryCommand.RemoveIndustry
{
    public class RemoveIndustryCommandRequest:IRequest<RemoveIndustryCommandResponse>
    {
        public int Id { get; set; }
    }
}
