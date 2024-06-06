using FluentValidation;
using JobSearchWebApi.Application.Features.Commands.StaffCommand.CreateStaff;
using JobSearchWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Validators.IndustryValidator
{
    public class CreateIndustryValidator:AbstractValidator<CreateIndustryCommandRequest>
    {
        public CreateIndustryValidator()
        {
            RuleFor(i => i.IndustryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter Industry Name")
                .Length(3, 45)
                .WithMessage("Please enter the industry name between 3 and 45 characters.");

            RuleFor(i => i.Icon)
                .NotEmpty()
                .NotNull()
                .Length(3, 200)
                .WithMessage("Please enter the industry icon url between 3 and 200 characters");
        }
    }
}
