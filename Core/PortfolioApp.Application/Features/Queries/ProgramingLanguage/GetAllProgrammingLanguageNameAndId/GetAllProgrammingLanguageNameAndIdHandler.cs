using MediatR;

namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguageNameAndId
{
    public class GetAllProgrammingLanguageNameAndIdHandler : IRequestHandler<GetAllProgrammingLanguageNameAndIdRequest, List<GetAllProgrammingLanguageNameAndIdResponse>>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetAllProgrammingLanguageNameAndIdHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<List<GetAllProgrammingLanguageNameAndIdResponse>> Handle(GetAllProgrammingLanguageNameAndIdRequest request, CancellationToken cancellationToken)
        {
            var response = _programmingLanguageReadRepository.Table.Where(t => !t.IsDeleted).Select(t => new GetAllProgrammingLanguageNameAndIdResponse
            {
                Id = t.Id.ToString(),
                ProgrammingLangName = t.Name
            }).ToList();

            return response;
        }
    }

    public class GetAllProgrammingLanguageNameAndIdResponse
    {
        public string ProgrammingLangName { get; set; }
        public string Id { get; set; }
    }

    public class GetAllProgrammingLanguageNameAndIdRequest : IRequest<List<GetAllProgrammingLanguageNameAndIdResponse>>
    {
    }
}
