﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.RemoveJob
{
    public class RemoveJobCommandResponse
    {
        public bool Succeess { get; set; }
        public string Message { get; set; }
    }
}
