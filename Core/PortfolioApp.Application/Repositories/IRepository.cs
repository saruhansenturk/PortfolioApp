using Microsoft.EntityFrameworkCore;
using PortfolioApp.Domain.Entities.Common;

namespace PortfolioApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; } //table'i al ama tabloya set islemi yapma.
    }
}
