using System.Text;
using MediatR;

namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguageUi
{
    public class GetAllProgrammingLangUiQueryHandler : IRequestHandler<GetAllProgrammingLangUiQueryRequest, GetAllProgrammingLangUiQueryResponse>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetAllProgrammingLangUiQueryHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<GetAllProgrammingLangUiQueryResponse> Handle(GetAllProgrammingLangUiQueryRequest request, CancellationToken cancellationToken)
        {
            var programmingLanguagesForUi = _programmingLanguageReadRepository.GetAll(request.Skip, request.Take, false);

            var mappedLanguagesUi = programmingLanguagesForUi.Items.Select(t => new GetAllProgrammingLanguageUiDto
            {
                Description = t.Description,
                LanguageImg = t.LanguageImg != null ? Encoding.UTF8.GetString(t.LanguageImg) : "",
                Level = t.Level,
                Name = t.Name,
            }).ToList();

            return new()
            {
                Data = mappedLanguagesUi,
                TotalCount = programmingLanguagesForUi.TotalCount
            };

        }
    }
}
