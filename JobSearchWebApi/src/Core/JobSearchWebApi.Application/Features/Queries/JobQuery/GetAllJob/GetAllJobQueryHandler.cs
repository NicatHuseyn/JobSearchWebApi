using JobSearchWebApi.Application.Repositories.JobRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.JobQuery.GetAllJob
{
    public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest, List<GetAllJobQueryResponse>>
    {
        private readonly IJobRepository _jobRepository;

        public GetAllJobQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<List<GetAllJobQueryResponse>> Handle(GetAllJobQueryRequest request, CancellationToken cancellationToken)
        {
            var jobs = _jobRepository.GetAll();

            return jobs.Select(x=> new GetAllJobQueryResponse
            {
                Id = x.Id,
                JobName = x.JobName,
                JobDescription = x.JobDescription,
                isNew = false,
                JobRequierment = x.JobRequierment,
                ViewCount = x.ViewCount,
                UpdateDate = x.UpdatedDate,
                CreateData = x.CreateData
            }).ToListAsync();
        }
    }
}
