using JobSearchWebApi.Application.Repositories.JobRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.JobQuery.GetByIdJob
{
    public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQueryRequest, GetByIdJobQueryResponse>
    {
        private readonly IJobRepository _jobRepository;

        public GetByIdJobQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<GetByIdJobQueryResponse> Handle(GetByIdJobQueryRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.Id);
            if (job is null)
            {
                return new GetByIdJobQueryResponse
                {
                    Success = false,
                    Message = "Job Not Found"
                };
            }

            try
            {
                return new GetByIdJobQueryResponse
                {
                    Id = job.Id,
                    JobDescription = job.JobDescription,
                    JobName = job.JobName,
                    isNew = false,
                    ViewCount = job.ViewCount,
                    JobRequierment = job.JobRequierment,
                    UpdateDate = job.UpdatedDate,
                    CreateData = job.CreateData,

                    Success = true,
                    Message = "Job Found Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdJobQueryResponse { Success = false, Message = ex.Message };
            }
        }
    }
}
