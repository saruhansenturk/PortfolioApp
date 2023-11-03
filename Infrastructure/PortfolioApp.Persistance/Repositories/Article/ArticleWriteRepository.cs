using PortfolioApp.Application;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Persistance.Contexts;
using PortfolioApp.Persistance.Repositories;

namespace PortfolioApp.Persistance;

public class ArticleWriteRepository: WriteRepository<Article>, IArticleWriteRepository
{
    public ArticleWriteRepository(PortfolioAppDbContext context) : base(context)
    {
    }
}