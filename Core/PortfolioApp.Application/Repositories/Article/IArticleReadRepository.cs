using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application
{
   
    public interface IArticleReadRepository : IReadRepository<Article>
    {
    }
}
