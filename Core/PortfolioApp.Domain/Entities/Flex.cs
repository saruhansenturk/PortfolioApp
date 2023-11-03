using PortfolioApp.Domain.Entities.Common;

namespace PortfolioApp.Domain.Entities
{
    public class Flex : BaseEntity
    {
        public string? FlexString1 { get; set; }
        public string? FlexString2 { get; set; }
        public string? FlexString3 { get; set; }
        public string? FlexString4 { get; set; }
        public string? FlexString5 { get; set; }
        public DateTime FlexDate1 { get; set; }
        public byte[]? FlexByte1 { get; set; }
        public byte[]? FlexByte2 { get; set; }
    }
}
