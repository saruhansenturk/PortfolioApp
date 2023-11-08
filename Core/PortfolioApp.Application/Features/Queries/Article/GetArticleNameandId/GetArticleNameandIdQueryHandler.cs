using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PortfolioApp.Application.Features.Queries.Article.GetArticleNameandId
{
    public class GetArticleNameandIdQueryHandler: IRequestHandler<GetArticleNameandIdQueryRequest, List<GetArticleNameandIdQueryResponse>>
    {

        private readonly IArticleReadRepository _articleReadRepository;

        public GetArticleNameandIdQueryHandler(IArticleReadRepository articleReadRepository)
        {
            _articleReadRepository = articleReadRepository;
        }

        public async Task<List<GetArticleNameandIdQueryResponse>> Handle(GetArticleNameandIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getArticleNameandId = _articleReadRepository.Table.Select(t => new GetArticleNameandIdQueryResponse
            {
                Id = t.Id,
                ArticleName = t.ArticleName
            }).ToList();


            return getArticleNameandId;
        }
    }

    public class GetArticleNameandIdQueryRequest : IRequest<List<GetArticleNameandIdQueryResponse>>
    {
    }

    public class GetArticleNameandIdQueryResponse
    {
        public Guid Id { get; set; }
        public string ArticleName { get; set; }
    }
}
