using JobSearchWebApi.Application.Repositories.IndustryRepository;
using JobSearchWebApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.StaffCommand.CreateStaff
{
    public class CreateIndustryCommandHandler : IRequestHandler<CreateIndustryCommandRequest, CreateIndustryCommandResponse>
    {
        private readonly IIndustryRepository _industryRepository;

        public CreateIndustryCommandHandler(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public async Task<CreateIndustryCommandResponse> Handle(CreateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _industryRepository.AddAsync(new Industry
                {
                    IndustryName = request.IndustryName,
                    Icon = request.Icon
                });
                await _industryRepository.SaveAsync();
                return new CreateIndustryCommandResponse
                {
                    Success = true,
                    Message = "Industry created successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateIndustryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
        }
    }
}
