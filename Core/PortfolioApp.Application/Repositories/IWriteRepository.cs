using PortfolioApp.Domain.Entities.Common;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<CommonResponse<T>> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<bool> Remove(string id);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        CommonResponse<T> Update(T model);

        Task<int> SaveAsync();
    }
}
