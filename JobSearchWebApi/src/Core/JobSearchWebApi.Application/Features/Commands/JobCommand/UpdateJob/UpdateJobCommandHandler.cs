using JobSearchWebApi.Application.Repositories.JobRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommandRequest, UpdateJobCommandResponse>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<UpdateJobCommandResponse> Handle(UpdateJobCommandRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.Id);
            if (job is null)
            {
                return new UpdateJobCommandResponse
                {
                    Success = false,
                    Message = "Job not found"
                };
            }

            try
            {
                job.JobName = request.JobName;
                job.JobDescription = request.JobDescription;
                job.isNew = request.isNew;
                job.JobRequierment = request.JobRequierment;

                _jobRepository.Update(job);
                await _jobRepository.SaveAsync();

                return new UpdateJobCommandResponse { Success = true, Message = "Job Update Successfully"};
            }
            catch (Exception ex)
            {
                return new UpdateJobCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
  