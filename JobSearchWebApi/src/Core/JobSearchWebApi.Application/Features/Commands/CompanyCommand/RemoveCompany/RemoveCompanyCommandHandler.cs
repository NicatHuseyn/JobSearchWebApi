using JobSearchWebApi.Application.Repositories.CompanyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CompanyCommand.RemoveCompany
{
    public class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommandRequest, RemoveCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;

        public RemoveCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<RemoveCompanyCommandResponse> Handle(RemoveCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            if (company is null)
            {
                return new RemoveCompanyCommandResponse
                {
                    Success = false,
                    Message = "company not found"
                };
            }

            try
            {
                _companyRepository.Remove(company);
                await _companyRepository.SaveAsync();
                return new RemoveCompanyCommandResponse
                {
                    Success = true,
                    Message = "Company deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new RemoveCompanyCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
