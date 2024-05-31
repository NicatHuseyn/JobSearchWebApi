using JobSearchWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.IndustryCommand.RemoveIndustry
{
    public class RemoveIndustryCommandHandler : IRequestHandler<RemoveIndustryCommandRequest, RemoveIndustryCommandResponse>
    {
        private readonly IIndustryRepository _industryRepository;

        public RemoveIndustryCommandHandler(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public async Task<RemoveIndustryCommandResponse> Handle(RemoveIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            var industry = await _industryRepository.GetByIdAsync(request.Id);
            if (industry is null)
            {
                new RemoveIndustryCommandResponse
                {
                    Success = false,
                    Message = "Industry not found"
                };
            }

            try
            {
                _industryRepository.Remove(industry);
                await _industryRepository.SaveAsync();

                return new RemoveIndustryCommandResponse
                {
                    Success = true,
                    Message = "Industry deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new RemoveIndustryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }
    }
}
