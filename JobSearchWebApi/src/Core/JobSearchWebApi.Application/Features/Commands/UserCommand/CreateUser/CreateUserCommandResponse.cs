using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.UserCommand.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
