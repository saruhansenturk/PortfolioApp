using PortfolioApp.Application;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class ProgrammingLanguageWriteRepository : WriteRepository<ProgrammingLanguage>, IProgrammingLanguageWriteRepository
    {
        public ProgrammingLanguageWriteRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
