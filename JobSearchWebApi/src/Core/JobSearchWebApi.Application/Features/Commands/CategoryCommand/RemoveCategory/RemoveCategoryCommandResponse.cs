using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.RemoveCategory
{
    public class RemoveCategoryCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
