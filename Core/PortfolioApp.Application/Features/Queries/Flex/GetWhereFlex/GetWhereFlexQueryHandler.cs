using MediatR;
using PortfolioApp.Application.Extensions;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Enums;

namespace PortfolioApp.Application.Features.Queries.Flex.GetWhereFlex
{
    public class GetWhereFlexQueryHandler : IRequestHandler<GetWhereFlexQueryRequest, CommonResponse<GetWhereFlexQueryResponse>>
    {
        private readonly IFlexReadRepository _flexReadRepository;

        public GetWhereFlexQueryHandler(IFlexReadRepository flexReadRepository)
        {
            _flexReadRepository = flexReadRepository;
        }

        public async Task<CommonResponse<GetWhereFlexQueryResponse?>> Handle(GetWhereFlexQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _flexReadRepository.Table.FirstOrDefault(t => t.FlexString1 == request.FlexEnum.ToString());

            if (response != null)
                return new CommonResponse<GetWhereFlexQueryResponse?>
                {
                    Data = response.MapTo<GetWhereFlexQueryResponse>(),
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<GetWhereFlexQueryResponse?>
            {
                Data = null,
                ResponseStatus = ResponseStatus.Fail
            };
        }
    }

    public class GetWhereFlexQueryRequest : IRequest<CommonResponse<GetWhereFlexQueryResponse>>
    {
        public FlexEnum FlexEnum { get; set; }
    }

    public class GetWhereFlexQueryResponse
    {
        public string? FlexString1 { get; set; }
        public string? FlexString2 { get; set; }
        public string? FlexString3 { get; set; }
        public string? FlexString4 { get; set; }
        public string? FlexString5 { get; set; }
        public DateTime FlexDate1 { get; set; }
        public byte[]? FlexByte1 { get; set; }
        public byte[]? FlexByte2 { get; set; }
    }
}
