using MediatR;
using PortfolioApp.Application.Extensions;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Queries.Article.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQueryRequest, CommonResponse<GetArticleByIdQueryResponse>>
    {
        private readonly IArticleReadRepository _articleReadRepository;

        public GetArticleByIdQueryHandler(IArticleReadRepository articleReadRepository)
        {
            _articleReadRepository = articleReadRepository;
        }

        public async Task<CommonResponse<GetArticleByIdQueryResponse>> Handle(GetArticleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var article = await _articleReadRepository.GetByIdAsync(request.Id, false);

            if (article == null)
                return new CommonResponse<GetArticleByIdQueryResponse>
                {
                    Data = null,
                    ResponseStatus = ResponseStatus.NoData,
                    Message = "There is no record for your search criteria!"
                };

            var mapped = article.MapTo<GetArticleByIdQueryResponse>();

            if (mapped != null) return new CommonResponse<GetArticleByIdQueryResponse> { Data = mapped, ResponseStatus = ResponseStatus.Success };


            return new CommonResponse<GetArticleByIdQueryResponse>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is no record for your search criteria!"
            };
        }
    }

    public class GetArticleByIdQueryRequest : IRequest<CommonResponse<GetArticleByIdQueryResponse>>
    {
        public string Id { get; set; }
    }

    public class GetArticleByIdQueryResponse
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Introduction { get; set; }
        public string Body { get; set; }
        public string Conclusion { get; set; }
        public string ArticleName { get; set; }
        public byte[]? Image { get; set; }
        public int LikeCount { get; set; }
        public Guid CategoryId { get; set; }
    }
}
