using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.UpdateCategory
{
    public class UpdateCategoryCommandRequest:IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
    }
}
