using PortfolioApp.Domain.Entities.Common;

namespace PortfolioApp.Domain.Entities;

public class Article: BaseEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Introduction { get; set; }
    public string Body { get; set; }
    public string Conclusion { get; set; }
    public string ArticleName { get; set; }
    public byte[]? Image { get; set; }
    public int LikeCount { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}