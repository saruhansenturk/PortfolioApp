using MediatR;
using PortfolioApp.Application.Extensions;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Commands.Flex.CreateFlex
{
    public class CreateFlexCommandHandler : IRequestHandler<CreateFlexCommandRequest, CommonResponse<bool>>
    {
        private readonly IFlexWriteRepository _flexWriteRepository;

        public CreateFlexCommandHandler(IFlexWriteRepository flexWriteRepository)
        {
            _flexWriteRepository = flexWriteRepository;
        }

        public async Task<CommonResponse<bool>> Handle(CreateFlexCommandRequest request, CancellationToken cancellationToken)
        {
            var addToEntity = request.MapTo<Domain.Entities.Flex>();

            var fileBytes = File.ReadAllBytes(
                   "C:\\Users\\srhn7\\OneDrive\\Masaüstü\\Personal\\Saruhan_Furkan_Senturk_Resume_2023.pdf");

            var base64Format = Convert.ToBase64String(fileBytes);

            addToEntity.FlexString5 = base64Format;

        var response = await _flexWriteRepository.AddAsync(addToEntity);

            var saveChanges = await _flexWriteRepository.SaveAsync();

            if (saveChanges > 0)
                return new CommonResponse<bool>
                {
                    Data = true,
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<bool>
            {
                Data = false,
                ResponseStatus = ResponseStatus.Fail
            };
        }
    }


    public class CreateFlexCommandRequest : IRequest<CommonResponse<bool>>
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
