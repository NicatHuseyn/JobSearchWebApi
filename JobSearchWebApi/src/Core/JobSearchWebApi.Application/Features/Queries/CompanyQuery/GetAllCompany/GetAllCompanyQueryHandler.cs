using JobSearchWebApi.Application.Repositories.CompanyRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CompanyQuery.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, List<GetAllCompanyQueryResponse>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<List<GetAllCompanyQueryResponse>> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var companies = _companyRepository.GetAll();
            return companies.Select(x=> new GetAllCompanyQueryResponse
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                Description = x.Description,
                Address = x.Address,
                Icon = x.Icon,
                PhoneNumber = x.PhoneNumber,
                WebSiteUrl = x.WebSiteUrl
            }).ToListAsync();
        }
    }
}
