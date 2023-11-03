using MediatR;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Commands.ProgrammingLangTech.DeleteProgrammingLangTech
{
    public class DeleteProgrammingLangTechHandler : IRequestHandler<DeleteProgrammingLangTechRequest, CommonResponse<bool>>
    {
        private readonly IProgrammingLanguageTechWriteRepository _programmingLanguageTechWriteRepository;
        private readonly IProgrammingLanguageTechReadRepository _programmingLanguageTechReadRepository;

        public DeleteProgrammingLangTechHandler(IProgrammingLanguageTechWriteRepository programmingLanguageTechWriteRepository, IProgrammingLanguageTechReadRepository programmingLanguageTechReadRepository)
        {
            _programmingLanguageTechWriteRepository = programmingLanguageTechWriteRepository;
            _programmingLanguageTechReadRepository = programmingLanguageTechReadRepository;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteProgrammingLangTechRequest request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechWriteRepository.Remove(request.Id);
            var saveResult = await _programmingLanguageTechWriteRepository.SaveAsync();

            if (saveResult > 0)
                return new CommonResponse<bool>
                {
                    Data = true,
                    ResponseStatus = ResponseStatus.Success,
                    Message = "Başarıyla silindi",
                };

            return new CommonResponse<bool>
            {
                Data = false,
                Message = "Silinirken bir hata oluştu!",
                ResponseStatus = ResponseStatus.Fail
            };
        }
    }


    public class DeleteProgrammingLangTechRequest : IRequest<CommonResponse<bool>>
    {
        public string Id { get; set; }
    }
}
