using JobSearchWebApi.Application.Repositories.CompanyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CompanyCommand.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            if (company is null)
            {
                return new UpdateCompanyCommandResponse
                {
                    Success = false,
                    Message = "Company not found"
                };
            }
            try
            {
                company.CompanyName = request.CompanyName;
                company.Icon = request.Icon;
                company.Address = request.Address;
                company.PhoneNumber = request.PhoneNumber;
                company.Description = request.Description;

                _companyRepository.Update(company);
                await _companyRepository.SaveAsync();

                return new UpdateCompanyCommandResponse
                {
                    Success = true,
                    Message = "Company update successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateCompanyCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
