using System.Text;
using MediatR;
using DomainObjects = PortfolioApp.Domain.Entities;


namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLangHandler : IRequestHandler<GetByIdProgrammingLangRequest, GetByIdProgrammingLangResponse>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetByIdProgrammingLangHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<GetByIdProgrammingLangResponse> Handle(GetByIdProgrammingLangRequest request, CancellationToken cancellationToken)
        {
            DomainObjects.ProgrammingLanguage? programmingLanguage =
                await _programmingLanguageReadRepository.GetByIdAsync(request.Id, false);

            return new()
            {
                Name = programmingLanguage.Name,
                CreatedDate = programmingLanguage.CreatedDate,
                Level = programmingLanguage.Level,
                UpdatedDate = programmingLanguage.UpdatedDate,
                Description = programmingLanguage.Description,
                LanguageImage = Encoding.UTF8.GetString(programmingLanguage.LanguageImg) 
            };
        }
    }
}
