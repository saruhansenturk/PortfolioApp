namespace PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLangResponse
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string LanguageImage { get; set; }
}