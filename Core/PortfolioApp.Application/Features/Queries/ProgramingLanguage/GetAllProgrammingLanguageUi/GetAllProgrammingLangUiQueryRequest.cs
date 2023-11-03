using MediatR;

namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguageUi;

public class GetAllProgrammingLangUiQueryRequest : IRequest<GetAllProgrammingLangUiQueryResponse>
{
    public int Skip { get; set; }
    public int Take { get; set; }
}