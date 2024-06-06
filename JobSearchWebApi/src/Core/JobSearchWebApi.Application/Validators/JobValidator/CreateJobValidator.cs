using FluentValidation;
using JobSearchWebApi.Application.Features.Commands.JobCommand.CreateJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Validators.JobValidator
{
    public class CreateJobValidator:AbstractValidator<CreateJobCommandRequest>
    {
        public CreateJobValidator()
        {
            RuleFor(j => j.JobName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your job name")
                .Length(3, 40)
                .WithMessage("Please enter the job name between 3 and 40 characters");

            RuleFor(j => j.JobDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your job description")
                .Length(3, 500)
                .WithMessage("Please enter your the job description betweem 3 and 500 characters");

            RuleFor(j => j.JobRequierment)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your Job Requierment")
                .Length(3, 50)
                .WithMessage("Please enter Job Requierment between 3 and 50 charecters");
        }
    }
}
