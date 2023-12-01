using MediatR;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Features.Commands.ProgrammingLang.UpdateProgrammingLang
{
    public class UpdateProgrammingLangHandler : IRequestHandler<UpdateProgrammingLangRequest, CommonResponse<bool>>
    {
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        public UpdateProgrammingLangHandler(IProgrammingLanguageWriteRepository programmingLanguageWriteRepository, IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<CommonResponse<bool>> Handle(UpdateProgrammingLangRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage updateToEntity = await _programmingLanguageReadRepository.GetByIdAsync(request.Id);
            if (updateToEntity != null)
            {
                updateToEntity.Name = request.Name;
                updateToEntity.Level = request.Level;
                updateToEntity.Description = request.Description;
            }

            _programmingLanguageWriteRepository.Update(updateToEntity);
            var saveChanges = await _programmingLanguageWriteRepository.SaveAsync();

            return new CommonResponse<bool>
            {
                Data = saveChanges > 0,
                ResponseStatus = saveChanges > 0 ? ResponseStatus.Success : ResponseStatus.Fail
            };
        }
    }

    public class UpdateProgrammingLangRequest : IRequest<CommonResponse<bool>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
