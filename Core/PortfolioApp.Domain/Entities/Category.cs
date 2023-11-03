using PortfolioApp.Domain.Entities.Common;

namespace PortfolioApp.Domain.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Article> Articles { get; set; }
}