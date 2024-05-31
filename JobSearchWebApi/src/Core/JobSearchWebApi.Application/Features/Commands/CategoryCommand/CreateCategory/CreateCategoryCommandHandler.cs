using JobSearchWebApi.Application.Repositories.CategroyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepsoitory _categoryRepsoitory;

        public CreateCategoryCommandHandler(ICategoryRepsoitory categoryRepsoitory)
        {
            _categoryRepsoitory = categoryRepsoitory;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryRepsoitory.AddAsync(new Domain.Entities.Category
                {
                    CategoryName = request.CategoryName,
                    Icon = request.Icon,
                });

                await _categoryRepsoitory.SaveAsync();

                return new CreateCategoryCommandResponse
                {
                    Success = true,
                    Message = "Create Category Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateCategoryCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
