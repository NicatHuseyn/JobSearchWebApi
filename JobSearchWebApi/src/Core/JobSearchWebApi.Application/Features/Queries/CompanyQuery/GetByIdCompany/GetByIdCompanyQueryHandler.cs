using JobSearchWebApi.Application.Repositories.CompanyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CompanyQuery.GetByIdCompany
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQueryRequest, GetByIdCompanyQueryResponse>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<GetByIdCompanyQueryResponse> Handle(GetByIdCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            if (company is null)
            {
                return new GetByIdCompanyQueryResponse
                {
                    Success = false,
                    Message = "Company not found"
                };
            }

            try
            {
                return new GetByIdCompanyQueryResponse
                {
                    Id = company.Id,
                    CompanyName = company.CompanyName,
                    Description = company.Description,
                    Address = company.Address,
                    Icon = company.Icon,
                    PhoneNumber = company.PhoneNumber,
                    WebSiteUrl = company.WebSiteUrl,

                    Success = true,
                    Message = "Category found successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdCompanyQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
