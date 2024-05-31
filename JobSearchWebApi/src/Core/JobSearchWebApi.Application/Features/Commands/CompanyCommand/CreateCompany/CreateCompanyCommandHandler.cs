using JobSearchWebApi.Application.Repositories.CompanyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CompanyCommand.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _companyRepository.AddAsync(new Domain.Entities.Company
                {
                    CompanyName = request.CompanyName,
                    Icon = request.Icon,
                    Description = request.Description,
                    Address = request.Address,
                    WebSiteUrl = request.WebSiteUrl,
                    PhoneNumber = request.PhoneNumber,
                });
                await _companyRepository.SaveAsync();

                return new CreateCompanyCommandResponse
                {
                    Success = true,
                    Message = "Company created successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateCompanyCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
