using JobSearchWebApi.Application.Repositories.JobRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.JobCommand.RemoveJob
{
    public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommandRequest, RemoveJobCommandResponse>
    {
        private readonly IJobRepository _jobRepository;

        public RemoveJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<RemoveJobCommandResponse> Handle(RemoveJobCommandRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.Id);

            if (job is null)
            {
                return new RemoveJobCommandResponse
                {
                    Succeess = false,
                    Message = "Job not found"
                };
            }
            try
            {
                _jobRepository.Remove(job);
                await _jobRepository.SaveAsync();

                return new RemoveJobCommandResponse { Succeess = true, Message = "Job Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new RemoveJobCommandResponse
                {
                    Succeess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
