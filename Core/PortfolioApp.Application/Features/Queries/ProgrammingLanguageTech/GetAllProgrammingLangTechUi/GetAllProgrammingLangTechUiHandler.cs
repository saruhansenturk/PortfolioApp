using System.Text;
using MediatR;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Queries.ProgrammingLanguageTech.GetAllProgrammingLangTechUi
{
    public class GetAllProgrammingLangTechUiQueryHandler : IRequestHandler<GetAllProgrammingLangTechUiQueryRequest, GetAllProgrammingLangTechUiQueryResponse>
    {
        private readonly IProgrammingLanguageTechReadRepository _programmingLanguageTechReadRepository;
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetAllProgrammingLangTechUiQueryHandler(IProgrammingLanguageTechReadRepository programmingLanguageTechReadRepository, IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageTechReadRepository = programmingLanguageTechReadRepository;
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<GetAllProgrammingLangTechUiQueryResponse> Handle(GetAllProgrammingLangTechUiQueryRequest request, CancellationToken cancellationToken)
        {
            var programmingLangTechs = _programmingLanguageTechReadRepository.GetAll(request.Skip, request.Take, false);

            var getProgrammingTechWithProgrammingLang = (from prgTech in programmingLangTechs.Items
                                                         join prgLang in _programmingLanguageReadRepository.Table
                                                             on
                                                             prgTech.ProgrammingLanguageId equals prgLang.Id
                                                         where !prgTech.IsDeleted
                                                         select new GetAllProgrammingLangTechUiDto
                                                         {
                                                             Name = prgTech.Name,
                                                             Level = prgTech.Level,
                                                             ProgrammingLanguageId = prgLang.Id.ToString(),
                                                             ProgrammingLanguageName = prgLang.Name,
                                                             LangTechImg = prgTech.LanguageTechImage != null ? Encoding.UTF8.GetString(prgTech.LanguageTechImage) : "",
                                                             Description = prgTech.Description
                                                         }).ToList();

            return new GetAllProgrammingLangTechUiQueryResponse
            {
                Data = getProgrammingTechWithProgrammingLang,
                TotalCount = programmingLangTechs.TotalCount
            };
        }
    }

    public class GetAllProgrammingLangTechUiQueryRequest : IRequest<GetAllProgrammingLangTechUiQueryResponse>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
    public class GetAllProgrammingLangTechUiQueryResponse : PagedResponse<GetAllProgrammingLangTechUiDto>
    {
    }
}
