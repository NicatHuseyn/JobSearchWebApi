using JobSearchWebApi.Application.Repositories.CategroyRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Queries.CategoryQuery.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryRepsoitory _categoryRepsoitory;

        public GetAllCategoryQueryHandler(ICategoryRepsoitory categoryRepsoitory)
        {
            _categoryRepsoitory = categoryRepsoitory;
        }

        public Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepsoitory.GetAll();
            return categories.Select(x=> new GetAllCategoryQueryResponse
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Icon = x.Icon,
                CreateData = x.CreateData,
                UpdateDate = x.UpdatedDate
            }).ToListAsync();
        }
    }
}
