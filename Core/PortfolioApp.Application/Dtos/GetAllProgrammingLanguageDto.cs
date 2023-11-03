using PortfolioApp.Domain.Entities.Common;

public class GetAllProgrammingLanguageDto: BaseEntity
{
    public string Name { get; set; }
    public int Level { get; set; }
}


public class GetAllProgrammingLangTechDto : BaseEntity
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string ProgrammingLanguageName { get; set; }
    public string ProgrammingLanguageId { get; set; }
}


public class GetAllProgrammingLanguageUiDto
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string LanguageImg { get; set; }
    public string? Description { get; set; }
}

public class GetAllProgrammingLangTechUiDto
{
    public string? Name { get; set; }
    public int Level { get; set; }
    public string? ProgrammingLanguageName { get; set; }
    public string? ProgrammingLanguageId { get; set; }
    public string? LangTechImg { get; set; }
    public string Description { get; set; }
}
