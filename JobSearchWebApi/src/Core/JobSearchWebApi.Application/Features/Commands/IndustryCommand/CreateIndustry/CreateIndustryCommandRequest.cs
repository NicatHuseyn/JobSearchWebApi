using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.StaffCommand.CreateStaff
{
    public class CreateIndustryCommandRequest:IRequest<CreateIndustryCommandResponse>
    {
        public string IndustryName { get; set; }
        public string Icon { get; set; }
    }
}
