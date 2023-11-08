using MediatR;
using PortfolioApp.Application.Extensions;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Queries.Flex.GetAllFlex
{
    public class GetAllFlexQueryHandler : IRequestHandler<GetAllFlexQueryRequest, GetAllFlexQueryResponse>
    {
        private readonly IFlexReadRepository _flexReadRepository;

        public GetAllFlexQueryHandler(IFlexReadRepository flexReadRepository)
        {
            _flexReadRepository = flexReadRepository;
        }

        public async Task<GetAllFlexQueryResponse> Handle(GetAllFlexQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _flexReadRepository.GetAll(request.Skip, request.Take, false);

            if (!response.Items.Any())
                return new GetAllFlexQueryResponse
                {
                    Data = null,
                    ResponseStatus = ResponseStatus.Fail
                };


            List<GetAllFlexDto?> mapped = response.Items.Select(t => t.MapTo<GetAllFlexDto>()).ToList();

            return new GetAllFlexQueryResponse
            {
                Data = new PagedResponse<GetAllFlexDto>
                {
                    Data = mapped,
                    TotalCount = response.TotalCount
                },
                ResponseStatus = ResponseStatus.Success
            };
        }
    }

    public class GetAllFlexQueryRequest : IRequest<GetAllFlexQueryResponse>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
    public class GetAllFlexQueryResponse : CommonResponse<PagedResponse<GetAllFlexDto>>
    {
    }
}
