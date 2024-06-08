﻿using JobSearchWebApi.Application.Exceptions.UserExceptions;
using JobSearchWebApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.UserCommand.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new AppUser
            {
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
            }, request.Password);


            // String Builder for error messages
            StringBuilder sb = new StringBuilder();

            if (result.Succeeded)
            {
                return new CreateUserCommandResponse
                {
                    Success = true,
                    Message = "Create User Successfully"
                };
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    sb.AppendLine($"Code:{error.Code} Message:{error.Description}");
                }
                return new CreateUserCommandResponse
                {
                    Success = false,
                    Message = sb.ToString()
                };
            }
        }
    }
}
