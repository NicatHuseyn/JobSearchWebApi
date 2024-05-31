using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.IndustryCommand.UpdateIndustry
{
    public class UpdateIndustryCommandRequest:IRequest<UpdateIndustryCommandResponse>
    {
        public int Id { get; set; }
        public string IndustryName { get; set; }
        public string Icon { get; set; }
    }
}
