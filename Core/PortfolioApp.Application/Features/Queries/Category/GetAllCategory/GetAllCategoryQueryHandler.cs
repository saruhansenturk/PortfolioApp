using MediatR;
using PortfolioApp.Application.Repositories;

namespace PortfolioApp.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.Table.Where(t => !t.IsDeleted).Select(t => new GetAllCategoryQueryResponse
            {
                Id = t.Id,
                CategoryName = t.Name
            }).ToList();

            if (categories.Any())
                return categories;

            return new List<GetAllCategoryQueryResponse>();
        }
    }


    public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
    {
    }

    public class GetAllCategoryQueryResponse
    {
        public string CategoryName { get; set; }
        public Guid Id { get; set; }
    }
}
