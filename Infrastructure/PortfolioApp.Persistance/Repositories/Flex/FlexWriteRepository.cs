using PortfolioApp.Application.Repositories;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class FlexWriteRepository: WriteRepository<Flex>, IFlexWriteRepository
    {
        public FlexWriteRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
