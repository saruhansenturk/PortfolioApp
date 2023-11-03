using PortfolioApp.Domain.Entities.Common;

namespace PortfolioApp.Domain.Entities
{
    public class ProgrammingLanguageTech : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public byte[]? LanguageTechImage { get; set; }

        public string Description { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
