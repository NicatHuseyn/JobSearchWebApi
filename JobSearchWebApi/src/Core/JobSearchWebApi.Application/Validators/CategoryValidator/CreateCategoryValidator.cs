using FluentValidation;
using JobSearchWebApi.Application.Features.Commands.CategoryCommand.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Validators.CategoryValidator
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.CategoryName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Enter your Company Name")
                .Length(3, 50)
                .WithMessage("Please enter Category Name between 3 and 50 charecters\"");

            RuleFor(c => c.Icon)
                .NotEmpty()
                .NotNull()
                .WithMessage("Enter your Category Icon")
                .Length(3, 50)
                .WithMessage("Please enter the Icon between 5 and 50 characeter");
        }
    }
}
