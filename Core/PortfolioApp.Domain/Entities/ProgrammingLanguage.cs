using PortfolioApp.Domain.Entities.Common;

namespace PortfolioApp.Domain.Entities
{
    public class ProgrammingLanguage : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public byte[]? LanguageImg { get; set; }
        public string Description { get; set; }
        public ICollection<ProgrammingLanguageTech> ProgrammingLanguageTechs { get; set; }
    }
}
