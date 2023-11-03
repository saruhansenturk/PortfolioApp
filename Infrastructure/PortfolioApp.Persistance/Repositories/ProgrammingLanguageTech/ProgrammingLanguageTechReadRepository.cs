using PortfolioApp.Application;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class ProgrammingLanguageTechReadRepository : ReadRepository<ProgrammingLanguageTech>, IProgrammingLanguageTechReadRepository
    {
        public ProgrammingLanguageTechReadRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
