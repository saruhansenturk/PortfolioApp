using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flexes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlexString1 = table.Column<string>(type: "text", nullable: true),
                    FlexString2 = table.Column<string>(type: "text", nullable: true),
                    FlexString3 = table.Column<string>(type: "text", nullable: true),
                    FlexString4 = table.Column<string>(type: "text", nullable: true),
                    FlexString5 = table.Column<string>(type: "text", nullable: true),
                    FlexDate1 = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FlexByte1 = table.Column<byte[]>(type: "bytea", nullable: true),
                    FlexByte2 = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flexes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flexes");
        }
    }
}
