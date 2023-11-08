using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Entities.Common;
using PortfolioApp.Domain.Entities.Identity;

namespace PortfolioApp.Persistance.Contexts
{
    public class PortfolioAppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public PortfolioAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTech> ProgrammingLanguageTechs { get; set; }
        public DbSet<Flex> Flexes { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
