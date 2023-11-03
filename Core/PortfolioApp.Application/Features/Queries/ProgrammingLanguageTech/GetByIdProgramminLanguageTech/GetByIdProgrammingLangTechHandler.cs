using System.Text;
using MediatR;
using PortfolioApp.Application.Extensions;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Features.Queries.ProgrammingLanguageTech.GetByIdProgramminLanguageTech
{
    public class GetByIdProgrammingLangTechHandler : IRequestHandler<GetByIdProgrammingLangTechRequest, GetByIdProgrammingLangTechResponse>
    {
        private readonly IProgrammingLanguageTechReadRepository _programmingLanguageTechReadRepository;
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

        public GetByIdProgrammingLangTechHandler(IProgrammingLanguageTechReadRepository programmingLanguageTechReadRepository, IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageTechReadRepository = programmingLanguageTechReadRepository;
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<GetByIdProgrammingLangTechResponse> Handle(GetByIdProgrammingLangTechRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProgrammingLanguageTech programmingLanguageTech = await _programmingLanguageTechReadRepository.GetByIdAsync(request.Id, false);
            var response = new GetByIdProgrammingLangTechResponse();
            if (programmingLanguageTech != null)
            {
                programmingLanguageTech.ProgrammingLanguage = await _programmingLanguageReadRepository.GetByIdAsync(programmingLanguageTech.ProgrammingLanguageId.ToString(), false);
                response = programmingLanguageTech?.MapTo<GetByIdProgrammingLangTechResponse>();
                response.LanguageTechImage = programmingLanguageTech.LanguageTechImage != null ? Encoding.UTF8.GetString(programmingLanguageTech.LanguageTechImage) : "";
            }

            return response;
        }
    }
    public class GetByIdProgrammingLangTechRequest : IRequest<GetByIdProgrammingLangTechResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdProgrammingLangTechResponse
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string? LanguageTechImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
