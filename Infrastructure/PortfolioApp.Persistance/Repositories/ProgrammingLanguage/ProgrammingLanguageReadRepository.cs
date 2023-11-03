using PortfolioApp.Application;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class ProgrammingLanguageReadRepository : ReadRepository<ProgrammingLanguage>, IProgrammingLanguageReadRepository
    {
        public ProgrammingLanguageReadRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
