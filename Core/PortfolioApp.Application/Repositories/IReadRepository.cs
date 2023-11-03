using PortfolioApp.Domain.Entities.Common;
using System.Linq.Expressions;
using PortfolioApp.Application.Paging;

namespace PortfolioApp.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Pagination<T> GetAll(int skip, int take, bool tracking = true);    //IQueryable ile yaparak ilgili veritabanı sorgusuna eklenir. Yani butun verileri getirip sorgulama yapmaz. 
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
