using Microsoft.EntityFrameworkCore;
using PortfolioApp.Application.Repositories;
using PortfolioApp.Domain.Entities.Common;
using PortfolioApp.Persistance.Contexts;
using System.Linq.Expressions;
using PortfolioApp.Application.Paging;

namespace PortfolioApp.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly PortfolioAppDbContext _context;

        public ReadRepository(PortfolioAppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public Pagination<T> GetAll(int skip, int take, bool tracking = true)
        {
            var totalCount = Table.AsQueryable().Count(t => !t.IsDeleted);
            var query = Table.AsQueryable()
                .Where(t => !t.IsDeleted)
                .Paginate(skip, take);

            if (!tracking)
                query = query.AsNoTracking();

            return new Pagination<T>(totalCount, query.ToList());
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id) && !t.IsDeleted);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var isDeletedExpression = GetIsDeletedExpression<T>();

            var combinedExpression = CombineExpression(method, isDeletedExpression);

            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(combinedExpression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var isDeletedExpression = GetIsDeletedExpression<T>();

            var combinedExpression = CombineExpression(method, isDeletedExpression);

            var query = Table.Where(combinedExpression);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
        
        // TODO bu metodları test et
        private Expression<Func<T, bool>> GetIsDeletedExpression<T>()
        {
            var parameter = Expression.Parameter(typeof(T), "t");
            var property = Expression.Property(parameter, "IsDeleted");
            var notExpression = Expression.Not(property);

            return Expression.Lambda<Func<T, bool>>(notExpression, parameter);
        }

        // TODO bu metodları test et
        private Expression<Func<T, bool>> CombineExpression(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T), "t");
            var combinedBody = Expression.AndAlso(expr1.Body, expr2.Body);
            var combinedExpression = Expression.Lambda<Func<T, bool>>(combinedBody, parameter);

            return combinedExpression;
        }

    }
}
