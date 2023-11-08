using PortfolioApp.Application;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;
using PortfolioApp.Persistance.Repositories;

namespace PortfolioApp.Persistance
{
    public class ArticleReadRepository: ReadRepository<Article>, IArticleReadRepository
    {
        public ArticleReadRepository(PortfolioAppDbContext context) : base(context)
        {
        }
    }
}
