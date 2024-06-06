using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.UpdateJob
{
    public class UpdateJobCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
