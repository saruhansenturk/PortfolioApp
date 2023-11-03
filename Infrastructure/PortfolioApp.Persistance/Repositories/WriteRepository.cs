using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PortfolioApp.Application.Exceptions.DatabaseExceptions;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities.Common;
using PortfolioApp.Persistance.Contexts;

namespace PortfolioApp.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly PortfolioAppDbContext _context;

        public WriteRepository(PortfolioAppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<CommonResponse<T>> AddAsync(T model)
        {
            EntityEntry<T> addedEntity = await Table.AddAsync(model);

            if (addedEntity.State == EntityState.Added)
            {
                return new CommonResponse<T>
                {
                    Data = addedEntity.Entity,
                    ResponseStatus = ResponseStatus.Success
                };
            }

            return new CommonResponse<T>
            {
                ResponseStatus = ResponseStatus.Fail
            };
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            try
            {
                await Table.AddRangeAsync(datas);
            }
            catch (Exception exception)
            {
                throw new AddRangeException(exception.Message, exception.InnerException);
            }
            return true;
        }
        
        public async Task<bool> Remove(string id)
        {
            T? deletedToEntity = await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));
            
            if (deletedToEntity != null)
            {
                deletedToEntity.IsDeleted = true;
                var updateToDeleted = Update(deletedToEntity).Data;
                return updateToDeleted.IsDeleted;
            }
            return false;
        }
        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<T> datas)
        {
            datas.ForEach(t =>
            {
                t.IsDeleted = true;
            });

            Table.UpdateRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public CommonResponse<T> Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);

            if (entityEntry.State == EntityState.Modified)
                return new CommonResponse<T>
                {
                    Data = entityEntry.Entity,
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<T>
            {
                ResponseStatus = ResponseStatus.Fail
            };
        }
    }
}
