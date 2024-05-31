using JobSearchWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.IndustryCommand.UpdateIndustry
{
    public class UpdateIndustryCommandHandler : IRequestHandler<UpdateIndustryCommandRequest, UpdateIndustryCommandResponse>
    {
        private readonly IIndustryRepository _industryRepository;

        public UpdateIndustryCommandHandler(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public async Task<UpdateIndustryCommandResponse> Handle(UpdateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            var industry = await _industryRepository.GetByIdAsync(request.Id);
            if (industry is null)
            {
                return new UpdateIndustryCommandResponse
                {
                    Success = false,
                    Message = "Industry not found"
                };
            }

            try
            {
                industry.IndustryName = request.IndustryName;
                industry.Icon = request.Icon;
                _industryRepository.Update(industry);
                await _industryRepository.SaveAsync();
                return new UpdateIndustryCommandResponse
                {
                    Success = true,
                    Message = "Update industry data"
                };
            }
            catch (Exception ex)
            {
                return new UpdateIndustryCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

        }
    }
}
