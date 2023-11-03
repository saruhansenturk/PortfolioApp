using MediatR;

namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLangRequest : IRequest<GetByIdProgrammingLangResponse>
{
    public string Id { get; set; }

}