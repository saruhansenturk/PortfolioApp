using MediatR;

namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguage;

public class GetAllProgrammingLangQueryRequest : IRequest<GetAllProgrammingLangQueryResponse>
{
    public int Skip { get; set; }
    public int Take { get; set; }
}