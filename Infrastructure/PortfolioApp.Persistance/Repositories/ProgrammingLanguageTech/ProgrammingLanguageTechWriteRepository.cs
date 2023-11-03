using PortfolioApp.Application;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories;

public class ProgrammingLanguageTechWriteRepository : WriteRepository<ProgrammingLanguageTech>, IProgrammingLanguageTechWriteRepository
{
    public ProgrammingLanguageTechWriteRepository(PortfolioAppDbContext context) : base(context)
    {
    }
}