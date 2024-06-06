using JobSearchWebApi.Application.Repositories.JobRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommandRequest, CreateJobCommandResponse>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<CreateJobCommandResponse> Handle(CreateJobCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _jobRepository.AddAsync(new Domain.Entities.Job
                {
                    JobName = request.JobName,
                    JobRequierment = request.JobRequierment,
                    JobDescription = request.JobDescription,
                    isNew = request.isNew,
                    CategoryId = request.CategoryId,
                    CompanyId  = request.CompanyId
                });

                var count = await _jobRepository.SaveAsync();

                return new CreateJobCommandResponse
                {
                    Success = true,
                    Message = "Job Create Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateJobCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
