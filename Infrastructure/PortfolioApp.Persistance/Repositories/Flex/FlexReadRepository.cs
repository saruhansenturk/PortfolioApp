using PortfolioApp.Application.Repositories;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class FlexReadRepository: ReadRepository<Flex>, IFlexReadRepository
    {
        public FlexReadRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
