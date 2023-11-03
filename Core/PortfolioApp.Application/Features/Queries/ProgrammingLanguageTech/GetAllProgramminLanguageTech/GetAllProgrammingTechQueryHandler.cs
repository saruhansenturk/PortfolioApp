using MediatR;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Features.Queries.ProgrammingLanguageTech.GetAllProgramminLanguageTech
{
    public class GetAllProgrammingTechQueryHandler : IRequestHandler<GetAllProgrammingTechQueryRequest, GetAllProgrammingTechQueryResponse>
    {

        private readonly IProgrammingLanguageTechReadRepository _programmingLanguageTechReadRepository;
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetAllProgrammingTechQueryHandler(IProgrammingLanguageTechReadRepository programmingLanguageTechReadRepository, IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageTechReadRepository = programmingLanguageTechReadRepository;
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<GetAllProgrammingTechQueryResponse> Handle(GetAllProgrammingTechQueryRequest request, CancellationToken cancellationToken)
        {
            var programmingLangTechs = _programmingLanguageTechReadRepository.GetAll(request.Skip, request.Take, false);
            var getProgrammingTechWithProgrammingLang = (from prgTech in programmingLangTechs.Items
                                                         join prgLang in _programmingLanguageReadRepository.Table
                                                             on
                                                             prgTech.ProgrammingLanguageId equals prgLang.Id
                                                         where !prgTech.IsDeleted
                                                         select new GetAllProgrammingLangTechDto
                                                         {
                                                             Name = prgTech.Name,
                                                             Level = prgTech.Level,
                                                             Id = prgTech.Id,
                                                             ProgrammingLanguageId = prgLang.Id.ToString(),
                                                             ProgrammingLanguageName = prgLang.Name,
                                                             IsDeleted = prgTech.IsDeleted,
                                                             CreatedDate = prgTech.CreatedDate,
                                                             UpdatedDate = prgTech.UpdatedDate
                                                         }).ToList();

            return new()
            {
                Data = getProgrammingTechWithProgrammingLang,
                TotalCount = programmingLangTechs.TotalCount
            };
        }
    }

    public class GetAllProgrammingTechQueryRequest : IRequest<GetAllProgrammingTechQueryResponse>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class GetAllProgrammingTechQueryResponse : PagedResponse<GetAllProgrammingLangTechDto>
    {
    }
}
