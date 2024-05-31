using JobSearchWebApi.Application.Repositories.CategroyRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CategoryQuery.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryRepsoitory _categoryRepsoitory;

        public GetByIdCategoryQueryHandler(ICategoryRepsoitory categoryRepsoitory)
        {
            _categoryRepsoitory = categoryRepsoitory;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepsoitory.GetByIdAsync(request.Id);

            if (category is null)
            {
                return new GetByIdCategoryQueryResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            try
            {
                return new GetByIdCategoryQueryResponse
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Icon = category.Icon,
                    CreateData = category.CreateData,
                    UpdateDate = category.UpdatedDate,

                    Success = true,
                    Message = "Category found successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdCategoryQueryResponse { Success = false, Message = ex.Message };
            }
        }
    }
}
