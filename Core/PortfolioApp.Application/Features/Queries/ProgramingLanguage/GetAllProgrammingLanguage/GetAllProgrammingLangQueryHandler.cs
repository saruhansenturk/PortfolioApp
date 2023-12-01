using MediatR;

namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguage
{
    public class GetAllProgrammingLangQueryHandler : IRequestHandler<GetAllProgrammingLangQueryRequest, GetAllProgrammingLangQueryResponse>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetAllProgrammingLangQueryHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<GetAllProgrammingLangQueryResponse> Handle(GetAllProgrammingLangQueryRequest request, CancellationToken cancellationToken)
        {
            var programmingLanguages = _programmingLanguageReadRepository.GetAll(request.Skip, request.Take, false);

            var mappedLanguages = programmingLanguages.Items.Select(t => new GetAllProgrammingLanguageDto
            {
                Id = t.Id,
                IsDeleted = t.IsDeleted,
                CreatedDate = t.CreatedDate,
                Level = t.Level,
                Name = t.Name,
                UpdatedDate = t.UpdatedDate,
                Description = t.Description
            }).ToList();

            return new()
            {
                Data = mappedLanguages,
                TotalCount = programmingLanguages.TotalCount
            };
            
        }
    }
}
