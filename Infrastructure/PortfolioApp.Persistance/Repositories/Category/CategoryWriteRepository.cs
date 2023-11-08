using PortfolioApp.Application.Repositories;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories;

public class CategoryWriteRepository: WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(PortfolioAppDbContext context) : base(context)
    {
    }
}