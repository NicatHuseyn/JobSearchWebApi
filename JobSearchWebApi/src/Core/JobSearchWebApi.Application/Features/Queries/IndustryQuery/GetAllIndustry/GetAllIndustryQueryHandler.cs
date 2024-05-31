 using JobSearchWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.IndustryQuery.GetAllIndustry
{
    public class GetAllIndustryQueryHandler : IRequestHandler<GetAllIndustryQueryRequest, List<GetAllIndustryQueryReponse>>
    {
        private readonly IIndustryRepository _industryRepository;

        public GetAllIndustryQueryHandler(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public Task<List<GetAllIndustryQueryReponse>> Handle(GetAllIndustryQueryRequest request, CancellationToken cancellationToken)
        {
            var industries = _industryRepository.GetAll();
            return industries.Select(x=> new GetAllIndustryQueryReponse
            {
                Id = x.Id,
                IndustryName = x.IndustryName,
                Icon = x.Icon,
                CreateData = x.CreateData,
                UpdateDate = x.UpdatedDate
            }).ToListAsync();
        }
    }
}
