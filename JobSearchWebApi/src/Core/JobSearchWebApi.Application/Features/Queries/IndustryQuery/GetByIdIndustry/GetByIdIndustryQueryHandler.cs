using JobSearchWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.IndustryQuery.GetByIdIndustry
{
    public class GetByIdIndustryQueryHandler : IRequestHandler<GetByIdIndustryQueryRequest, GetByIdIndustryQueryResponse>
    {
        private readonly IIndustryRepository _industryRepository;

        public GetByIdIndustryQueryHandler(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public async Task<GetByIdIndustryQueryResponse> Handle(GetByIdIndustryQueryRequest request, CancellationToken cancellationToken)
        {
            var industry = await _industryRepository.GetByIdAsync(request.Id);

            if (industry is null)
            {
                return new GetByIdIndustryQueryResponse
                {
                    Success = false,
                    Message = "Industry not found"
                };
            }

            try
            {
                return new GetByIdIndustryQueryResponse
                {
                    Id = industry.Id,
                    IndustryName = industry.IndustryName,
                    Icon = industry.Icon,
                    CreateData = industry.CreateData,
                    UpdateDate = industry.UpdatedDate,
                    Success = true,
                    Message = "Industry found successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdIndustryQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }

            
        }
    }
}
