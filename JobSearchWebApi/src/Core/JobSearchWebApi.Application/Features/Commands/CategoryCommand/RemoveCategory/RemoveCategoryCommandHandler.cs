using JobSearchWebApi.Application.Repositories.CategroyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
    {
        private readonly ICategoryRepsoitory _categoryRepsoitory;

        public RemoveCategoryCommandHandler(ICategoryRepsoitory categoryRepsoitory)
        {
            _categoryRepsoitory = categoryRepsoitory;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepsoitory.GetByIdAsync(request.Id);
            if (category is null)
            {
                return new RemoveCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            try
            {
                _categoryRepsoitory.Remove(category);
                await _categoryRepsoitory.SaveAsync();

                return new RemoveCategoryCommandResponse
                {
                    Success = true,
                    Message = "Category deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new RemoveCategoryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
