using MediatR;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Commands.ProgrammingLang.DeleteProgrammingLang
{
    public class DeleteProgrammingLangHandler : IRequestHandler<DeleteProgrammingLangRequest, CommonResponse<bool>>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;

        public DeleteProgrammingLangHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository, IProgrammingLanguageWriteRepository programmingLanguageWriteRepository)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteProgrammingLangRequest request, CancellationToken cancellationToken)
        {
            await _programmingLanguageWriteRepository.Remove(request.Id);
            var saveChanges = await _programmingLanguageWriteRepository.SaveAsync();

            if (saveChanges > 0)
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

    public class DeleteProgrammingLangRequest : IRequest<CommonResponse<bool>>
    {
        public string Id { get; set; }
    }
}
