using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.CreateCategory
{
    public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
        public string Icon { get; set; }
    }
}
