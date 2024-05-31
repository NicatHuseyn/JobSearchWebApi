using JobSearchWebApi.Application.Repositories.CategroyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepsoitory _categoryRepsoitory;

        public UpdateCategoryCommandHandler(ICategoryRepsoitory categoryRepsoitory)
        {
            _categoryRepsoitory = categoryRepsoitory;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepsoitory.GetByIdAsync(request.Id);
            if (category is null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            try
            {
                category.CategoryName = request.CategoryName;
                category.Icon = request.Icon;

                _categoryRepsoitory.Update(category);
                await _categoryRepsoitory.SaveAsync();

                return new UpdateCategoryCommandResponse
                {
                    Success = true,
                    Message = "Category updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
