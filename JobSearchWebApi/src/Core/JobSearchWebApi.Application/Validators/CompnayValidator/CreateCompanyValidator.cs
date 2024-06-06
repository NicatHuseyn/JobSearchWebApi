using FluentValidation;
using JobSearchWebApi.Application.Features.Commands.CompanyCommand.CreateCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Validators.CompnayValidator
{
    public class CreateCompanyValidator:AbstractValidator<CreateCompanyCommandRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(c => c.CompanyName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please enter your Company Name")
                .Length(3, 50)
                .WithMessage("Please enter Company Name between 3 and 50 charecters");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Enter your Phone Number")
                .Length(10, 20)
                .WithMessage("Please enter the phone number between 10 and 20 characeter");

            RuleFor(c => c.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Enter your Address")
                .Length(5, 50)
                .WithMessage("Please enter the address between 5 and 50 characeter");

            RuleFor(c => c.Icon)
                .NotEmpty()
                .NotNull()
                .WithMessage("Enter your Company Icon")
                .Length(5, 50)
                .WithMessage("Please enter the Icon between 5 and 50 characeter");
        }
    }
}
