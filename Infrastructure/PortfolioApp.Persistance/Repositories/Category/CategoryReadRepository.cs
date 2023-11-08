using PortfolioApp.Application.Repositories;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class CategoryReadRepository: ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
