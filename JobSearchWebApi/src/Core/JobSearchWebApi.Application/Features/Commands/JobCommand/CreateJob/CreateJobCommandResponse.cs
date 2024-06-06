using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.CreateJob
{
    public class CreateJobCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
